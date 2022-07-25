using System;
using MicroRogue.Core.AI;
using System.Xml.Serialization;
using System.IO;
using MicroRogue.Core.Menu.MenuActions;
using MicroRogue.Core.Menu;

namespace MicroRogue.Core
{
    public class Game
    {
        public Scene CurrentScene;
        public Unit[] Units;
        public Unit PlayerUnit;
        public Menu.Menu Menu;
        public void LoadDemo()
        {
            Random ran = new Random();
            ConsoleColor seekerColor = ConsoleColor.White;
            ConsoleColor unitColor = ConsoleColor.Red;
            ConsoleColor playerColor = ConsoleColor.Green;
            CurrentScene = new Scene(20, 10);
            CurrentScene.FillDemoTiles();
            Units = new Unit[] {
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Dummy()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", unitColor, 15, 15).WithAI(new Roach()),
                new Unit(ran.Next(1, CurrentScene.width), ran.Next(1, CurrentScene.height), "☺", seekerColor, 15, 15).WithAI(new Seeker())
            };
            PlayerUnit = new Unit(5, 5, "☻", playerColor, 50, 25, "Ferret");
        }
        public void Initialize()
        {
            Menu = CreateMainMenu();
        }
        public Menu.Menu CreateMainMenu()
        {
            Menu.Menu menu = new Menu.Menu();
            menu.Menus = new Menu.MenuItem[] {
                new Menu.MenuItem("1.Start", new StartDemoAction()),
                new Menu.MenuItem("2.Exit", new ExitAction())
            };
            return menu;
        }
        public Menu.Menu CreateEscapeMenu()
        {
            Menu.Menu menu = new Menu.Menu();
            menu.Menus = new Menu.MenuItem[]
            {
                new Menu.MenuItem("1.Continue", new ContinueAction()),
                new Menu.MenuItem("2.QuickSave", new QuickSaveAction()),
                new Menu.MenuItem("3.QuickLoad", new QuickLoadAction()),
                new Menu.MenuItem("4.Exit to MainMenu", new ExitGameAction())
            };
            return menu;
        }
        public void SaveGame()
        {
            XmlSerializer Xml = new XmlSerializer(typeof(SaveObjects.Game));
            SaveObjects.Game game = SaveObjects.Game.ToSaveGame(this);
            using (FileStream fs = new FileStream(@"D:\Kirill\Projects\MicroRogue\Saves\Save.xml", FileMode.Create))
            {
                Xml.Serialize(fs, game);
            }
        }
        public void LoadGame()
        {
            XmlSerializer Xml = new XmlSerializer(typeof(SaveObjects.Game));
            using (FileStream fs = new FileStream(@"D:\Kirill\Projects\MicroRogue\Saves\Save.xml", FileMode.Open))
            {
                SaveObjects.Game loadedGame = (SaveObjects.Game)Xml.Deserialize(fs);
                Game game = loadedGame.ToGame();
                CurrentScene = game.CurrentScene;
                PlayerUnit = game.PlayerUnit;
                Units = game.Units;
            }
        }
        public bool ProcessKey(ConsoleKey key)
        {
            //Random ran = new Random();
            //PlayerUnit.Hp = ran.Next(PlayerUnit.MaxHp);
            //PlayerUnit.Mp = ran.Next(PlayerUnit.MaxMp);
            int i;
            if (Menu != null)
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        i = 0;
                        if (i <= Menu.Menus.Length - 1)
                            Menu.Menus[i].Action.Action(this);
                        return true;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        i = 1;
                        if (i <= Menu.Menus.Length - 1)
                        {
                            Menu.Menus[i].Action.Action(this);
                            if (Menu.Menus[i].Action.Type == ActionType.ExitAction)
                                return false;
                            else
                                return true;
                        }
                        return true;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        i = 2;
                        if (i <= Menu.Menus.Length - 1)
                            Menu.Menus[i].Action.Action(this);
                        return true;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        i = 3;
                        if (i <= Menu.Menus.Length - 1)
                            Menu.Menus[i].Action.Action(this);
                        return true;
                    default:
                        return true;
                }
            }
            else
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        PlayerUnit.MoveUp(CurrentScene);
                        break;
                    case ConsoleKey.DownArrow:
                        PlayerUnit.MoveDown(CurrentScene);
                        break;
                    case ConsoleKey.LeftArrow:
                        PlayerUnit.MoveLeft(CurrentScene);
                        break;
                    case ConsoleKey.RightArrow:
                        PlayerUnit.MoveRight(CurrentScene);
                        break;
                }
                foreach (Unit unit in Units)
                {
                    unit.ExecuteAI(this);
                }
                return true;
            }
        }
    }
}
