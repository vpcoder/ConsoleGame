using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Мост
    /// </summary>
    public class Bridge : Object
    {

        public Bridge()
        {
            this.Symbol   = '═';
            this.Color    = Color.DarkRed;
            this.Walkable = true;
        }

    }

}
