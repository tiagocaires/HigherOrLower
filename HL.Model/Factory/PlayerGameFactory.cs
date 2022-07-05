using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class PlayerGameFactory
    {
        public static PlayerGame Create(int pGameId, int pPlayerId, int pOrder)
        {
            return new PlayerGame
            {
                GameId = pGameId,
                PlayerId = pPlayerId,
                Order = pOrder,
                Score = 0,
            };
        }
    }
}
