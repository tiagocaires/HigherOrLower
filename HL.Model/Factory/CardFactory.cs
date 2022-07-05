using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class CardFactory
    {
        private static int MaxNumberCard = 13;

        public static Card Create()
        {
            return new Card
            {
                Number = new Random().Next(1, MaxNumberCard),
                Suit = (ESuit)new Random().Next(0, Enum.GetNames(typeof(ESuit)).Length),
            };
        }

        public static int MaxCardsPossible()
        {
            return Enum.GetNames(typeof(ESuit)).Length * MaxNumberCard;
        }
    }
}
