using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Дорога
    /// </summary>
    public class Road : Object
    {

        public Road()
        {
            this.Symbol   = '░';
            this.Color    = ConsoleColor.DarkGray;
            this.Walkable = true;
        }

    }

}
