using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class PlayerFactory
    {
        public static Player Create(string pName, string pEmail)
        {
            return new Player
            {
                Email = pEmail,
                Name = pName,
            };
        }
    }
}
