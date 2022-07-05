using AutoMapper;
using HL.Data;
using HL.Model;
using HL.Model.Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class StepAnswerService : IStepAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IStepService _stepService;
        private readonly HLContext _context;

        public StepAnswerService(IMapper mapper, HLContext hLContext, IStepService stepService)
        {
            _mapper = mapper;
            _context = hLContext;
            _stepService = stepService;
        }

        public async Task<IActionResult> Create(StepAnswerNewRequest pStepNewRequest)
        {
            try
            {
                var maxCards = CardFactory.MaxCardsPossible();

                List<Step> steps = _context.Steps.Where(x => x.GameId == pStepNewRequest.GameId).ToList();
                if (steps.Count == maxCards)
                    return new BadRequestObjectResult("The Game has reached as many cards as possible.");

                var previousStep = steps.Where(x => x.GameId == pStepNewRequest.GameId).OrderByDescending(x => x.Date).FirstOrDefault();

                var nextStepActionResult = await _stepService.Create(new StepNewRequest { GameId = pStepNewRequest.GameId, PlayerToId = pStepNewRequest.PlayerId });
                var objectNextStepResult = nextStepActionResult as OkObjectResult;
                var nextStep = objectNextStepResult.Value as StepRequest;

                var stepAnswer = StepAnswerFactory.Create(pStepNewRequest.GameId, pStepNewRequest.PlayerId, previousStep.Id, nextStep.Id, pStepNewRequest.Answer,
                                                        previousStep.CardNumber, previousStep.CardSuit,
                                                        nextStep.CardNumber, nextStep.CardSuit);
                _context.StepAnswers.Add(stepAnswer);
                _context.SaveChanges();

                var nextStepDataBase = _context.Steps.Include(x => x.Game).Include(x => x.PlayerTo).FirstOrDefault(x => x.Id == nextStep.Id);

                var stepAnswerRequest = _mapper.Map<StepAnswerRequest>(stepAnswer);
                stepAnswerRequest.Text = steps.Count + 1 == maxCards
                    ? $"The final card for {nextStepDataBase.Game.Name} is {nextStepDataBase.CardNumber} of {nextStepDataBase.CardSuit}."
                    : $"The card in {nextStepDataBase.Game.Name} is {nextStepDataBase.CardNumber} of {nextStepDataBase.CardSuit}. {stepAnswer.Result}.";
                return new OkObjectResult(stepAnswerRequest);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }
    }
}
