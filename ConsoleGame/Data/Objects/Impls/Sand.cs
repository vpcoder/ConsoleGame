using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Песок
    /// </summary>
    public class Sand : Object
    {

        public Sand()
        {
            this.Symbol   = '░';
            this.Color    = ConsoleColor.Yellow;
            this.Walkable = true;
        }

    }

}
