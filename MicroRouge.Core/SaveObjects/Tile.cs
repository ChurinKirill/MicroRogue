using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public struct Tile
    {
        public Wall Wall;
        public Floor Floor;
        public int X;
        public int Y;
        public static Tile ToSaveTile(Core.Tile tile, int x, int y)
        {
            Tile saveTile = new Tile();
            saveTile.Wall = Wall.ToSaveWall(tile.Wall);
            saveTile.Floor = Floor.ToSaveFloor(tile.Floor);
            saveTile.X = x;
            saveTile.Y = y;
            return saveTile;
        }
        public Core.Tile ToTile()
        {
            Core.Tile newTile = new Core.Tile();
            if (Wall != null)
                newTile.Wall = Wall.ToWall();
            if (Floor != null)
                newTile.Floor = Floor.ToFloor();
            return newTile;
            
        }
    }
}
