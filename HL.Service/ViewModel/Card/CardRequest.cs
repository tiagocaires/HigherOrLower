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
    public class CardRequest : CardNewRequest
    {
        public int Id { get; set; }
    }

    public class CardNewRequest : IRequest<IActionResult>
    {
        public ESuit Suit { get; set; }
        public int Number { get; set; }
    }
}
