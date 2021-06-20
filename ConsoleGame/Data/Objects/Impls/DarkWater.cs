using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Глубокие воды
    /// </summary>
    public class DarkWater : Object
    {

        public DarkWater()
        {
            this.Symbol   = '▒';
            this.Color    = ConsoleColor.DarkBlue;
            this.Walkable = false;
        }

    }

}
