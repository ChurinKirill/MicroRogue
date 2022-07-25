using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class StartDemoAction : MenuAction
    {
        public override void Action(Game game)
        {
            game.LoadDemo();
            game.Menu = null;
        }
    }
}
