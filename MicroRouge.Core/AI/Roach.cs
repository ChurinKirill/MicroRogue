using System;

namespace MicroRogue.Core.AI
{
    class Roach : BaseAI
    {
        static Random ran = new Random();

        public override void Execute(Unit unit, Game game)
        {
            int direction = ran.Next(4);
            switch (direction)
            {
                case 0:
                    unit.MoveLeft(game.CurrentScene);
                    break;
                case 1:
                    unit.MoveRight(game.CurrentScene);
                    break;
                case 2:
                    unit.MoveUp(game.CurrentScene);
                    break;
                case 3:
                    unit.MoveDown(game.CurrentScene);
                    break;
            }
        }
    }
}
