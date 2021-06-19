using System;

namespace Engine.Data.Impls
{

    public class Brick : Object
    {

        public override char Symbol { get; } = '█';

        public override ConsoleColor Color { get { return ConsoleColor.DarkRed; } }

        public override bool Walkable { get { return false; } }

    }

}
