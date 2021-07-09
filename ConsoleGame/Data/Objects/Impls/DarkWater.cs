using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Глубокие воды
    /// </summary>
    public class DarkWater : Object
    {

        public DarkWater()
        {
            this.ID = "tile/darkwater";
            this.Color    = Color.DarkBlue;
            this.Walkable = false;
        }

    }

}
