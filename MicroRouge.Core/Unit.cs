using System;
using MicroRogue.Core.AI;
namespace MicroRogue.Core
{
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
        public Unit(int x, int y, string icon, ConsoleColor color, int maxHp, int maxMp, string name = "0")
        {
            this.x = x;
            this.y = y;
            MaxHp = maxHp;
            MaxMp = maxMp;
            Hp = 3;
            Mp = 7;
            ico = icon;
            unitColor = color;
            Name = name;
        }
        public void ExecuteAI(Game game)
        {
            if (behavior != null)
                behavior.Execute(this, game);
        }
        internal Unit WithAI(BaseAI newBehavior)
        {
            behavior = newBehavior;
            return this;
        }
        public void MoveUp(Scene scene)
        {
            if (scene.CanMove(x, y - 1))
                --y;
        }
        public void MoveDown(Scene scene)
        {
            if (scene.CanMove(x, y + 1))
                ++y;
        }
        public void MoveLeft(Scene scene)
        {
            if (scene.CanMove(x - 1, y))
                --x;
        }
        public void MoveRight(Scene scene)
        {
            if (scene.CanMove(x + 1, y))
                ++x;
        }
    }

}
