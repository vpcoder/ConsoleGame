using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Трава
    /// </summary>
    public class Grass : Object
    {

        public Grass()
        {
            this.ID = "tile/grass";
            this.Color    = Color.DarkGreen;
            this.Walkable = true;
        }

    }

}
