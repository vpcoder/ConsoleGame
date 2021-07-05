using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Земля
    /// </summary>
    public class Dirt : Object
    {

        public Dirt()
        {
            this.Symbol   = '░';
            this.Color    = Color.DarkGreen;
            this.Walkable = true;
        }

    }

}
