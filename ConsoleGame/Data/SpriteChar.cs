using System;

namespace Engine.Data
{

    public abstract class SpriteChar
    {

        public virtual char Symbol { get; }

        public virtual ConsoleColor Color { get; set; }

        public virtual int PosX { get; set; }

        public virtual int PosY { get; set; }

    }

}
