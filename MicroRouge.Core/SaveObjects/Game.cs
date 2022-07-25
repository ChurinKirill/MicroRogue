using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRogue.Core.SaveObjects
{
    [Serializable]
    public class Game
    {
        public Scene CurrentScene;
        public Unit[] Units;
        public Unit PlayerUnit;
        public static Game ToSaveGame(Core.Game game)
        {
            Game saveGame = new Game();
            saveGame.CurrentScene = Scene.ToSaveScene(game.CurrentScene);
            saveGame.PlayerUnit = Unit.ToSaveUnit(game.PlayerUnit);
            saveGame.Units = game.Units.Select(unit => Unit.ToSaveUnit(unit)).ToArray();
            return saveGame;
        }
        public Core.Game ToGame()
        {
            Core.Game newGame = new Core.Game();
            newGame.CurrentScene = CurrentScene.ToScene();
            newGame.PlayerUnit = PlayerUnit.ToUnit();
            newGame.Units = Units.Select(unit => unit.ToUnit()).ToArray();
            return newGame;
        }
    }
}
