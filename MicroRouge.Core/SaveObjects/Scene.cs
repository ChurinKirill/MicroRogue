using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public class Scene
    {
        public int width;
        public int height;
        public Tile[] Tiles;

        internal static Scene ToSaveScene(Core.Scene currentScene)
        {
            Scene saveScene = new Scene();
            saveScene.height = currentScene.height;
            saveScene.width = currentScene.width;
            var tiles = new Tile[currentScene.width * currentScene.height];
            for (int y = 0; y < currentScene.height; y++)
            {
                for (int x = 0; x < currentScene.width; x++)
                {
                    tiles[currentScene.width * y + x] = Tile.ToSaveTile(currentScene.tiles[x, y], x, y);
                }
            }
            saveScene.Tiles = tiles;
            return saveScene;
        }

        internal Core.Scene ToScene()
        {
            Core.Scene scene = new Core.Scene(width, height);
            Core.Tile[,] tiles2d = new Core.Tile[width, height];
            foreach (Tile tile in Tiles)
            {
                tiles2d[tile.X, tile.Y] = tile.ToTile();
            }
            scene.WithTiles(tiles2d);
            return scene;
        }
    }
}