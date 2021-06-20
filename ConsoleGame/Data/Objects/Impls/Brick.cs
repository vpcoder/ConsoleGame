using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Кирпичная стена
    /// </summary>
    public class Brick : Object
    {

        public Brick()
        {
            this.Symbol   = '█';
            this.Color    = ConsoleColor.DarkRed;
            this.Walkable = false;
        }

    }

}
