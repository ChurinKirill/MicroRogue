using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class ContinueAction : MenuAction
    {
        public override void Action(Game game)
        {
            game.Menu = null;
        }
    }
}
