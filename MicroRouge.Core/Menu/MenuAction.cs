namespace MicroRogue.Core.Menu
{
    public abstract class MenuAction
    {
        public ActionType Type;
        public abstract void Action(Game game);
    }
}