using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public class Unit
    {
        public string ico = "☺";
        public int x;
        public int y;
        public ConsoleColor unitColor;
        public int Hp;
        public int Mp;
        public int MaxHp;
        public int MaxMp;
        public string Name;
        BaseAI behavior;

        internal static Unit ToSaveUnit(Core.Unit playerUnit)
        {
            Unit saveUnit = new Unit();
            saveUnit.ico = playerUnit.ico;
            saveUnit.x = playerUnit.x;
            saveUnit.y = playerUnit.y;
            saveUnit.unitColor = playerUnit.unitColor;
            saveUnit.Hp = playerUnit.Hp;
            saveUnit.MaxHp = playerUnit.MaxHp;
            saveUnit.Mp = playerUnit.Mp;
            saveUnit.MaxMp = playerUnit.MaxMp;
            saveUnit.Name = playerUnit.Name;
            return saveUnit;
        }
        public Core.Unit ToUnit()
        {
            Core.Unit newUnit = new Core.Unit(x, y, ico, unitColor, MaxHp, MaxMp, Name);
            return newUnit;
        }
    }
}
