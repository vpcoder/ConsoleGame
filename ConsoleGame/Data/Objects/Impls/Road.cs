using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Дорога
    /// </summary>
    public class Road : Object
    {

        public Road()
        {
            this.ID   = "tile/road";
            this.Walkable = true;
        }

    }

}
