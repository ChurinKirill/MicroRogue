using System;

namespace MicroRogue.Core.AI
{
    class Seeker : BaseAI
    {
        public override void Execute(Unit unit, Game game)
        {
            if (unit.x < game.PlayerUnit.x)
                unit.MoveRight(game.CurrentScene);
            else
                unit.MoveLeft(game.CurrentScene);
            if (unit.y < game.PlayerUnit.y)
                unit.MoveDown(game.CurrentScene);
            else
                unit.MoveUp(game.CurrentScene);
        }
    }
}
