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
    public class PlayerGameHandler :
        IRequestHandler<PlayerGameByGameId, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IPlayerGameService _service;

        public PlayerGameHandler(IMapper mapper, IPlayerGameService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IActionResult> Handle(PlayerGameByGameId model, CancellationToken cancellationToken)
        {
            return _service.GetByGame(model);
        }

    }
}
