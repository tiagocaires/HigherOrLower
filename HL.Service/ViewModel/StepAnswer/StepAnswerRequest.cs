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
    public class StepAnswerRequest : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public StepRequest PreviousStep { get; set; }
        public int PreviousStepId { get; set; }
        public PlayerRequest Player { get; set; }
        public int PlayerId { get; set; }
        public EStepAnswer Answer { get; set; }
        public StepRequest NextStep { get; set; }
        public int NextStepId { get; set; }
        public EStepResult Result { get; set; }
        public string Text { get; set; }

    }

    public class StepAnswerNewRequest : IRequest<IActionResult>
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Answer { get; set; }
    }
}
