using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class QuickSaveAction : MenuAction
    {
        public override void Action(Game game)
        {
            game.SaveGame();
        }
    }
}
