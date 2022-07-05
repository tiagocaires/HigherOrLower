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

namespace HL.Service
{
    public class StepService : IStepService
    {
        private readonly IMapper _mapper;
        private readonly HLContext _context;

        public StepService(IMapper mapper, HLContext hLContext)
        {
            _mapper = mapper;
            _context = hLContext;
        }

        public async Task<IActionResult> Create(StepNewRequest pStepNewRequest)
        {
            try
            {
                var maxCards = CardFactory.MaxCardsPossible();
                List<Step> steps = _context.Steps.Where(x => x.GameId == pStepNewRequest.GameId).ToList();

                Step step = StepFactory.Create(pStepNewRequest.GameId, pStepNewRequest.PlayerToId);
                var stepRepeated = steps.FirstOrDefault(x => x.CardNumber == step.CardNumber && x.CardSuit == step.CardSuit);
                while (stepRepeated != null && steps.Count <= maxCards)
                {
                    step = StepFactory.Create(pStepNewRequest.GameId, pStepNewRequest.PlayerToId);
                    stepRepeated = steps.FirstOrDefault(x => x.CardNumber == step.CardNumber && x.CardSuit == step.CardSuit);
                }

                _context.Steps.Add(step);
                _context.SaveChanges();

                var stepRequest = _mapper.Map<StepRequest>(step);

                return new OkObjectResult(stepRequest);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }
    }
}
