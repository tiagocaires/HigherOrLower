using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model
{
    public class Card
    {
        public int Id { get; set; }
        public ESuit Suit { get; set; }
        public int Number { get; set; }
    }
}
