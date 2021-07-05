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
            this.Symbol   = '░';
            this.Color    = Color.DarkGray;
            this.Walkable = true;
        }

    }

}
