using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Кактус
    /// </summary>
    public class Cactus : Object
    {

        public Cactus()
        {
            this.Symbol   = 'Ψ';
            this.Color    = ConsoleColor.Green;
            this.Walkable = false;
        }

    }

}
