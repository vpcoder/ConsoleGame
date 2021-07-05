using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Вода
    /// </summary>
    public class Water : Object
    {

        public Water()
        {
            this.Symbol   = '░';
            this.Color    = Color.Blue;
            this.Walkable = false;
        }

    }

}
