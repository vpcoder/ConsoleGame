using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Земля
    /// </summary>
    public class Dirt : Object
    {

        public Dirt()
        {
            this.Symbol   = '░';
            this.Color    = ConsoleColor.DarkGreen;
            this.Walkable = true;
        }

    }

}
