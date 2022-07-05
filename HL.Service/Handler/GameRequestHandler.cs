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
    public class GameRequestHandler :
        IRequestHandler<GameNewRequestNew, IActionResult>,
        IRequestHandler<GameScoreRequest, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IGameService _service;

        public GameRequestHandler(IMapper mapper, IGameService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IActionResult> Handle(GameNewRequestNew model, CancellationToken cancellationToken)
        {
            return await _service.Create(model);
        }

        public async Task<IActionResult> Handle(GameScoreRequest model, CancellationToken cancellationToken)
        {
            return _service.Score(model);
        }
    }
}
