using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Кирпичная стена
    /// </summary>
    public class Brick : Object
    {

        public Brick()
        {
            this.ID = "tile/brick";
            this.Color    = Color.DarkRed;
            this.Walkable = false;
        }

    }

}
