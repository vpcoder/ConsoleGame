using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Вода
    /// </summary>
    public class Water : Object
    {

        public Water()
        {
            this.Symbol   = '░';
            this.Color    = ConsoleColor.Blue;
            this.Walkable = false;
        }

    }

}
