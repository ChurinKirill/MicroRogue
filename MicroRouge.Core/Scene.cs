using System;

namespace MicroRogue.Core
{
    public class Scene
    {
        public int width;
        public int height;
        public Tile[,] tiles;
        public Scene(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
        }
        public bool CanMove(int nextX, int nextY)
        {
            if (nextY < 0)
                return false;
            else if (nextY >= height)
                return false;
            if (nextX < 0)
                return false;
            else if (nextX >= width)
                return false;
            if (tiles[nextX, nextY].Wall != null)
                return false;
            if (tiles[nextX, nextY].Floor == null)
                return false;
            return true;
        }
        public void FillDemoTiles()
        {
            Random ran = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = new Tile();
                    if (x == 0 || x == width - 1)
                        tile.Wall = new Wall("▓", ConsoleColor.DarkMagenta);
                    else if (y == 0 || y == height - 1)
                        tile.Wall = new Wall("▓", ConsoleColor.DarkMagenta);
                    else
                        tile.Wall = null;
                    tile.Floor = new Floor("░", ConsoleColor.Yellow);
                    tiles[x, y] = tile;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                int a = ran.Next(width);
                int b = ran.Next(height);
                tiles[a, b].Wall = new Wall("▓", ConsoleColor.DarkMagenta);
            }
        }

        internal void WithTiles(Tile[,] tiles2d)
        {
            tiles = tiles2d;
        }
    }
}