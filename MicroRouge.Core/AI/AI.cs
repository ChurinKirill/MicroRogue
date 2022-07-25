using System;

namespace MicroRogue.Core.AI
{
    abstract class BaseAI
    {
        public abstract void Execute(Unit unit, Game game);
    }
}
