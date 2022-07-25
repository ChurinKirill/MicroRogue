using System;

namespace MicroRogue.Core
{
    public class Floor
    {
        public string ico;
        public ConsoleColor floorColor;
        public Floor(string newIco, ConsoleColor color)
        {
            ico = newIco;
            floorColor = color;
        }
    }
}
