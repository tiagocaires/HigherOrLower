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
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly HLContext _context;

        public PlayerService(IMapper mapper, HLContext hLContext)
        {
            _mapper = mapper;
            _context = hLContext;
        }

        public async Task<IActionResult> Create(PlayerNewRequest pPlayerRequest)
        {
            try
            {
                Player player = PlayerFactory.Create(pPlayerRequest.Name, pPlayerRequest.Email);
                _context.Players.Add(player);
                _context.SaveChanges();

                var playerRequest = _mapper.Map<PlayerRequest>(player);

                return new OkObjectResult(playerRequest);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error....");
            }
        }
    }
}
