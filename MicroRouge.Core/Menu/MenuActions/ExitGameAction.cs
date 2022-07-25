using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class ExitGameAction : MenuAction
    {
        public override void Action(Game game)
        {
            game.Menu = game.CreateMainMenu();
        }
    }
}
