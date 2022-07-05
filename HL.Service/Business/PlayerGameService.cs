using AutoMapper;
using HL.Data;
using HL.Model;
using HL.Model.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class PlayerGameService : IPlayerGameService
    {
        private readonly IMapper _mapper;
        private readonly HLContext _context;

        public PlayerGameService(IMapper mapper, HLContext hLContext)
        {
            _mapper = mapper;
            _context = hLContext;
        }

        public IActionResult Create(PlayerGameNewRequest pPlayerGameRequest)
        {
            try
            {
                PlayerGame playerGame = PlayerGameFactory.Create(pPlayerGameRequest.Game.Id, pPlayerGameRequest.Player.Id, pPlayerGameRequest.Order);
                _context.PlayerGames.Add(playerGame);
                _context.SaveChanges();

                var playerGameRequest = _mapper.Map<PlayerGameRequest>(playerGame);

                return new OkObjectResult(playerGameRequest);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }

        public IActionResult GetByGame(PlayerGameByGameId pPlayerGameByGameId)
        {
            try
            {
                var players = _context.PlayerGames.Where(x => x.GameId == pPlayerGameByGameId.GameId).Select(x => x.Player).ToList();
                List<PlayerRequest> playersGame = new List<PlayerRequest>();
                foreach (var player in players)
                    playersGame.Add(_mapper.Map<PlayerRequest>(player));
                return new OkObjectResult(playersGame);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }
    }
}
