using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class PlayerGameRequest : PlayerGameNewRequest
    {
        public int Id { get; set; }
    }

    public class PlayerGameNewRequest : IRequest<IActionResult>
    {
        public PlayerRequest Player { get; set; }
        public GameRequest Game { get; set; }
        public int Order { get; set; }
        public int Score { get; set; }
    }

    public class PlayerGameNewGameRequest : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Order { get; set; }
    }

    public class PlayerGameByGameId : IRequest<IActionResult>
    {
        public int GameId { get; set; }
    }
}
