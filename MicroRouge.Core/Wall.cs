using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core
{
    public class Wall
    {
        public string ico;
        public ConsoleColor wallColor;
        public Wall(string newIco, ConsoleColor color)
        {
            ico = newIco;
            wallColor = color;
        }
    }
}
