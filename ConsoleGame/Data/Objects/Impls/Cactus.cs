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
            this.ID = "tile/cactus";
            this.Color    = Color.Green;
            this.Walkable = false;
        }

    }

}
