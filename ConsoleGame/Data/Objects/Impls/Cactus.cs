using System;
using System.Drawing;

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
            this.Color    = Color.Green;
            this.Walkable = false;
        }

    }

}
