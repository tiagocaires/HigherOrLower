using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model
{
    public class StepAnswer
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Step PreviousStep { get; set; }
        public int PreviousStepId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public EStepAnswer Answer { get; set; }
        public Step NextStep { get; set; }
        public int NextStepId { get; set; }
        public EStepResult Result { get; set; }
    }
}
