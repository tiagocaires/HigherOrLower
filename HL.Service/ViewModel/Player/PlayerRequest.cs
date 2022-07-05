using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public class PlayerRequest : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class PlayerNewRequest : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
