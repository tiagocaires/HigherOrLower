using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class GameRequest : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Text { get; set; }
    }

    public class GameNewRequest : IRequest<IActionResult>
    {
        public List<PlayerGameNewRequest> Players { get; set; }
    }

    public class GameNewRequestNew : IRequest<IActionResult>
    {
        public List<PlayerGameNewGameRequest> Players { get; set; }
    }
}
