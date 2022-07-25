using System;

namespace MicroRogue.Core.Menu.MenuActions
{
    public class ExitAction : MenuAction
    {
        public ExitAction()
        {
            Type = ActionType.ExitAction;
        }
        public override void Action(Game game)
        {
        }
    }
}

