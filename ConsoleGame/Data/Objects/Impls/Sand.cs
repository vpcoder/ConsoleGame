using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Песок
    /// </summary>
    public class Sand : Object
    {

        public Sand()
        {
            this.ID = "tile/sand";
            this.Color    = Color.Yellow;
            this.Walkable = true;
        }

    }

}
