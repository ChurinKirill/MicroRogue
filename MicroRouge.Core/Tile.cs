using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core
{
    // ░▒▓
    public struct Tile
    {
        public Wall Wall;
        public Floor Floor;
        public Tile(Wall wall, Floor floor)
        {
            Wall = wall;
            Floor = floor;
        }
    }
}