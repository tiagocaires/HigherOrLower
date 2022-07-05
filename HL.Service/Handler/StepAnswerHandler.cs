using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service.Handler
{
    public class StepAnswer :
        IRequestHandler<StepAnswerNewRequest, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IStepAnswerService _service;

        public StepAnswer(IMapper mapper, IStepAnswerService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IActionResult> Handle(StepAnswerNewRequest model, CancellationToken cancellationToken)
        {
            return await _service.Create(model);
        }
    }
}
