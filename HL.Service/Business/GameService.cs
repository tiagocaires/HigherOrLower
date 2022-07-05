using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Model;
using AutoMapper;
using HL.Model.Factory;
using HL.Data;
using Microsoft.EntityFrameworkCore;

namespace HL.Service
{
    public class GameService : IGameService
    {
        private readonly IPlayerGameService _playerGameService;
        private readonly IPlayerService _playerService;
        private readonly IStepService _stepService;
        private readonly IMapper _mapper;
        private readonly HLContext _context;

        public GameService(IMapper mapper, HLContext hLContext, IPlayerGameService playerGameService, IPlayerService playerService, IStepService stepService)
        {
            _mapper = mapper;
            _context = hLContext;
            _playerGameService = playerGameService;
            _playerService = playerService;
            _stepService = stepService;
        }

        public async Task<IActionResult> Create(GameNewRequestNew pGameRequest)
        {
            try
            {
                Game game = GameFactory.Create();
                _context.Games.Add(game);
                _context.SaveChanges();

                List<PlayerGameNewRequest> newPlayerGameNewRequest = new List<PlayerGameNewRequest>();
                foreach (var playerGameRequest in pGameRequest.Players.OrderBy(x => x.Order))
                {
                    PlayerNewRequest playerNewRequest = new PlayerNewRequest { Email = playerGameRequest.Email, Name = playerGameRequest.Name };

                    var playerActionResult = await _playerService.Create(playerNewRequest);
                    var objectPlayerResult = playerActionResult as OkObjectResult;
                    var playerRequest = objectPlayerResult.Value as PlayerRequest;

                    PlayerGameNewRequest playerGameNewRequest = new PlayerGameNewRequest
                    {
                        Game = new GameRequest { Id = game.Id },
                        Order = playerGameRequest.Order,
                        Player = new PlayerRequest { Id = playerRequest.Id },
                    };

                    _playerGameService.Create(playerGameNewRequest);

                    newPlayerGameNewRequest.Add(playerGameNewRequest);
                }

                var stepActionResult = await _stepService.Create(new StepNewRequest
                {
                    GameId = game.Id,
                    PlayerToId = newPlayerGameNewRequest.OrderBy(x => x.Order).First().Player.Id,
                });
                var objectStepAciont = stepActionResult as OkObjectResult;
                var step = objectStepAciont.Value as StepRequest;

                var gameRequest = _mapper.Map<GameRequest>(game);
                gameRequest.Text = $"The first card from {game.Name} is {step.CardNumber} of {step.CardSuit}";

                return new OkObjectResult(gameRequest);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }

        public IActionResult Score(GameScoreRequest pGameScoreRequest)
        {
            try
            {
                var maxCard = CardFactory.MaxCardsPossible();
                var game = _context.Games.FirstOrDefault(x => x.Id == pGameScoreRequest.Id);
                var answers = _context.StepAnswers.Include(x => x.Player).Where(x => x.GameId == pGameScoreRequest.Id).ToList();
                var answersGroup = answers.Where(x => x.Result == EStepResult.Correct)
                                            .GroupBy(x => x.Player)
                                            .Select(x => new
                                            {
                                                Player = x.Key,
                                                Total = x.Count()
                                            })
                                            .ToList();

                var textResult = answers.Count == maxCard - 1 ? "final result" : "current score";
                var text = $"The {textResult} for the {game?.Name ?? ""} is ";
                foreach (var item in answersGroup)
                    text += $"{item.Player.Name}:{item.Total} and";
                text = text.Substring(0, text.Length - 3);

                return new OkObjectResult(text);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }
    }
}
