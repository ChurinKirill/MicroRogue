using System;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using MicroRogue.Core;
using MicroRogue.Console;
using MicroRogue.Core.Menu;
using MicroRogue.Core.Menu.MenuActions;

namespace MicroRogue
{
    class Program
    {
        public static void PrintBorders(Camera cameraSize)
        {
            for (int leftPos = 0; leftPos < cameraSize.width + 2; ++leftPos)
            {
                System.Console.SetCursorPosition(leftPos, 0);
                System.Console.Write("*");
                System.Console.SetCursorPosition(leftPos, cameraSize.height + 1);
                System.Console.Write("*");
            }
            for (int topPos = 1; topPos < cameraSize.height + 1; ++topPos)
            {
                System.Console.SetCursorPosition(0, topPos);
                System.Console.Write("*");
                System.Console.SetCursorPosition(cameraSize.width + 1, topPos);
                System.Console.Write("*");
            }
        }
        public static void DrawUnit(Unit unit, Camera camera)
        {
            System.Console.ForegroundColor = unit.unitColor;
            if ((unit.x - camera.LeftPos) + 1 > 0 && (unit.y - camera.TopPos) + 1 > 0)
            {
                System.Console.SetCursorPosition((unit.x - camera.LeftPos) + 1, (unit.y - camera.TopPos) + 1);
                System.Console.Write(unit.ico);
            }
        }
        public static void DrawGame(Game game, Camera camera, Menu menu)
        {
            if (menu != null)
            {
                DrawMenu(menu);
            }
            else
            {
                DrawScene(game.CurrentScene, camera);
                DrawUnits(game, camera);
                System.Console.ForegroundColor = ConsoleColor.White;
                DrawStatistics(game.PlayerUnit, camera);
            }
        }
        public static void UpdateCamPos(Game game, Camera Camera)
        {
            Camera.LeftPos = game.PlayerUnit.x - Camera.width / 2;
            Camera.TopPos = game.PlayerUnit.y - Camera.height / 2;
            if (Camera.LeftPos < 0)
                Camera.LeftPos = 0;
            if (Camera.LeftPos > game.CurrentScene.width - Camera.width)
                Camera.LeftPos = game.CurrentScene.width - Camera.width;
            if (Camera.TopPos < 0)
                Camera.TopPos = 0;
            if (Camera.TopPos > game.CurrentScene.height - Camera.height)
                Camera.TopPos = game.CurrentScene.height - Camera.height;
        }
        public static void DrawScene(Scene scene, Camera camera)
        {
            PrintBorders(camera);
            int i = 1;
            for (int y = camera.TopPos; y < camera.TopPos + camera.height; y++)
            {
                System.Console.SetCursorPosition(1, i);
                ++i;
                for (int x = camera.LeftPos; x < camera.LeftPos + camera.width; x++)
                {
                    if (scene.tiles[x, y].Wall == null)
                    {
                        if (scene.tiles[x, y].Floor != null)
                        {
                            System.Console.ForegroundColor = scene.tiles[x, y].Floor.floorColor;
                            System.Console.Write(scene.tiles[x, y].Floor.ico);
                        }
                    }
                    else
                    {
                        System.Console.ForegroundColor = scene.tiles[x, y].Wall.wallColor;
                        System.Console.Write(scene.tiles[x, y].Wall.ico);
                    }
                    //System.Console.SetCursorPosition((x - cameraSize.LeftPos) + 1, (y - cameraSize.TopPos) + 1);
                }
            }
        }
        public static void DrawUnits(Game game, Camera camera)
        {
            foreach (Unit unit in game.Units)
            {
                //(unit.x - camera.LeftPos) + 1, (unit.y - camera.TopPos + 1
                if (unit.y > camera.TopPos && unit.y < camera.TopPos + camera.height)
                    if (unit.x > camera.LeftPos && unit.x < camera.LeftPos + camera.width)
                        DrawUnit(unit, camera);
            }
            DrawUnit(game.PlayerUnit, camera);
        }
        public static void DrawStatistics(Unit unit, Camera camera)
        {
            //▓
            int startPos = 17;
            int width = (camera.width + 2) - startPos;
            float countHpInCell = unit.MaxHp / (float)width;
            float countMpInCell = unit.MaxMp / (float)width;

            System.Console.SetCursorPosition(0, camera.height + 2);
            System.Console.WriteLine($"Name | {unit.Name}");
            System.Console.Write($"Hp   | {unit.Hp} / {unit.MaxHp}" + " ");
            System.Console.SetCursorPosition(startPos, camera.height + 3);
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(new String('▓', (int)Math.Ceiling(unit.Hp / (decimal)countHpInCell)));
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine(new String('▒', width - (int)Math.Ceiling(unit.Hp / (decimal)countHpInCell)));

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"Mp   | {unit.Mp} / {unit.MaxMp}" + " ");
            System.Console.SetCursorPosition(startPos, camera.height + 4);
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write(new String('▓', (int)Math.Ceiling(unit.Mp / (decimal)countMpInCell)));
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine(new String('▒', width - (int)Math.Ceiling(unit.Mp / (decimal)countMpInCell)));
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DrawMenu(Menu menu)
        {
            System.Console.Clear();
            foreach (MenuItem m in menu.Menus)
            {
                System.Console.WriteLine(m.Label);
            }
        }
        //public static bool ProcessMenuKey(ActionType type, ConsoleKey key, Game game)
        //{
        //    switch (key)
        //    {
        //        case ConsoleKey.D1:
        //        case ConsoleKey.NumPad1:
        //            if (type == ActionType.GameAction)
        //            {
        //                StartDemoAction start = new StartDemoAction();
        //                start.Action(game);
        //            }
        //            else
        //            {
        //                ContinueAction cont = new ContinueAction();
        //                cont.Action(game);
        //            }
        //            return true;
        //        case ConsoleKey.D2:
        //        case ConsoleKey.NumPad2:
        //            if (type == ActionType.GameAction)
        //            {
        //                ExitAction exit = new ExitAction();
        //                exit.Action(game);
        //                return false;
        //            }
        //            else
        //            {
        //                QuickSaveAction save = new QuickSaveAction();
        //                save.Action(game);
        //                return true;
        //            }
        //        case ConsoleKey.D3:
        //        case ConsoleKey.NumPad3:
        //            if (type == ActionType.ExitAction)
        //            {
        //                QuickLoadAction load = new QuickLoadAction();
        //                load.Action(game);
        //            }
        //            return true;
        //        case ConsoleKey.D4:
        //        case ConsoleKey.NumPad4:
        //            if (type == ActionType.ExitAction)
        //            {
        //                ExitGameAction exitGame = new ExitGameAction();
        //exitGame.Action(game);
        //                type = ActionType.GameAction;
        //                type = exitGame.Type;
        //                DrawMenu(game, type, game.Menu);
        //                ProcessMenuKey(type, System.Console.ReadKey().Key, game);
        //            }
        //            return false;
        //        default:
        //            return true;
        //    }
        //}
        static void Main(string[] args)
        {
            System.Console.CursorVisible = false;
            System.Console.Title = "MicroRogue";
            System.Console.SetWindowSize(80, 50);
            System.Console.SetBufferSize(80, 50);
            Game game = new Game();
            Camera Camera = new Camera(20, 10);
            game.Initialize();
            //if (game.Menu != null)
            //{
            //    DrawMenu(game.Menu);
            //    bool b = game.ProcessKey(System.Console.ReadKey().Key);
            //    if (b == false)
            //        return;
            //}
            game.LoadDemo();
            while (true)
            {
                UpdateCamPos(game, Camera);
                DrawGame(game, Camera, game.Menu);
                ConsoleKey key = System.Console.ReadKey().Key;
                if (!game.ProcessKey(key))
                    return;
                if (key == ConsoleKey.Escape)
                {
                    game.Menu = game.CreateEscapeMenu();
                    DrawMenu(game.Menu);
                    ////bool b = ProcessMenuKey(type, System.Console.ReadKey().Key, game);
                    if (game.ProcessKey(System.Console.ReadKey().Key) == false)
                        return;
                }
                System.Console.Clear();
            }
        }
    }
}
