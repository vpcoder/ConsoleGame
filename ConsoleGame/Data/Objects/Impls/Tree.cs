using System;
using System.Drawing;

namespace Engine.Data.Impls
{

    /// <summary>
    /// Дерево
    /// </summary>
    public class Tree : Object
    {

        public Tree()
        {
            this.ID = "tile/tree";
            this.Color    = Color.Green;
            this.Walkable = false;
        }

    }

}
