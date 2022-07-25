using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class QuickLoadAction : MenuAction
    {
        public override void Action(Game game)
        {
            game.LoadGame();
        }
    }
}
