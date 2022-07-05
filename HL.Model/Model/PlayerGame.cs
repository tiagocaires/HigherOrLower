using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model
{
    public class PlayerGame
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int Order { get; set; }
        public int Score { get; set; }
    }
}
