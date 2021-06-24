namespace Engine.Data
{

    public class Player : SpriteChar
    {

        public override char Symbol { get; } = '☺';

        public int HP { get; set; }

        public int AtackDamage { get; set; }

        public int Armor { get; set; }

    }

}
