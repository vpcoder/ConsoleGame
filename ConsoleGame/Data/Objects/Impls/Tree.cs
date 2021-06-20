using System;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Дерево
    /// </summary>
    public class Tree : Object
    {

        public Tree()
        {
            this.Symbol   = '♣';
            this.Color    = ConsoleColor.Green;
            this.Walkable = false;
        }

    }

}
