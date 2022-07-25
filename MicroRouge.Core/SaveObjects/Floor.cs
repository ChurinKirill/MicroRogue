using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public class Floor
    {
        public string ico;
        public ConsoleColor floorColor;
        public static Floor ToSaveFloor(Core.Floor floor)
        {
            Floor saveFloor = new Floor();
            if (floor != null)
            {
                saveFloor.ico = floor.ico;
                saveFloor.floorColor = floor.floorColor;
                return saveFloor;
            }
            else
                return null;
        }

        internal Core.Floor ToFloor()
        {
            Core.Floor floor = new Core.Floor(ico, floorColor);
            return floor;
        }
    }
}
