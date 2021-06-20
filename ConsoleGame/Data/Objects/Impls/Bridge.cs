using System;

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
            this.Color    = ConsoleColor.DarkRed;
            this.Walkable = true;
        }

    }

}
