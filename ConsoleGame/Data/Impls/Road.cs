using System;

namespace Engine.Data.Impls
{

    public class Road : Object
    {

        public override char Symbol { get; } = '░';

        public override ConsoleColor Color { get { return ConsoleColor.DarkBlue; } }

        public override bool Walkable { get { return false; } }

    }

}
