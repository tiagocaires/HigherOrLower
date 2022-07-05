using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class GameFactory
    {
        public static Game Create()
        {
            return new Game
            {
                Name = $"Game {Guid.NewGuid().ToString().ToUpper()}",
                Start = DateTime.UtcNow,
            };
        }
    }
}
