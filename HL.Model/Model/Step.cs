using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model
{
    public class Step
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public int CardNumber { get; set; }
        public ESuit CardSuit { get; set; }
        public Player PlayerTo { get; set; }
        public int PlayerToId { get; set; }
    }
}
