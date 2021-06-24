using System;

namespace Engine.Data.Impls
{

    public class Tree : Object
    {

        public override char Symbol { get; } = 'Ψ';

        public override ConsoleColor Color { get { return ConsoleColor.Green; } }

        public override bool Walkable { get { return false; } }

    }
}
