using System;

namespace Engine.Data
{

    public class Player : SpriteChar
    {

        public override ConsoleColor Color { get; set; } = ConsoleColor.Yellow;

        public override char Symbol { get; } = '☺';

        public int HP { get; set; }

        public int AttackDamage { get; set; }

        public int Armor { get; set; }

    }

}
