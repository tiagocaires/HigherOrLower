using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class StepFactory
    {
        public static Step Create(int pGameId, int pPlayerToId)
        {
            var card = CardFactory.Create();
            return new Step
            {
                CardNumber = card.Number,
                CardSuit = card.Suit,
                Date = DateTime.UtcNow,
                GameId = pGameId,
                PlayerToId = pPlayerToId,
            };
        }
    }
}
