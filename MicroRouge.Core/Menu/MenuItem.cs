namespace MicroRogue.Core.Menu
{
    public class MenuItem
    {
        public string Label;
        public MenuAction Action;
        public MenuItem(string label, MenuAction action)
        {
            Label = label;
            Action = action;
        }
    }
}