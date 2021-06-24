using System;

namespace Engine.Data.Impls
{

    public class Brick : Object
    {

        public override char Symbol { get; } = '█';

        public override ConsoleColor Color { get { return ConsoleColor.DarkBlue; } }

        public override bool Walkable { get { return false; } }

    }

}
