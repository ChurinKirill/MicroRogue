using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public class Wall
    {
        public string ico;
        public ConsoleColor wallColor;
        public static Wall ToSaveWall(Core.Wall wall)
        {
            Wall saveWall = new Wall();
            if (wall != null)
            {
                saveWall.ico = wall.ico;
                saveWall.wallColor = wall.wallColor;
                return saveWall;
            }
            else
                return null;
        }
        public Core.Wall ToWall()
        {
            Core.Wall newWall = new Core.Wall(ico, wallColor);
            return newWall;
        }
    }
}
