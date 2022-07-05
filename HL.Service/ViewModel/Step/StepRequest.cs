using HL.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class StepRequest : StepNewRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CardNumber { get; set; }
        public ESuit CardSuit { get; set; }
        public PlayerRequest PlayerTo { get; set; }
        public GameRequest Game { get; set; }
    }

    public class StepNewRequest : IRequest<IActionResult>
    {
        public int PlayerToId { get; set; }
        public int GameId { get; set; }
    }
}
