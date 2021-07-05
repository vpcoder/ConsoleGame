using System;


namespace Engine.Data
{

    public abstract class NPC : SpriteChar
    {

        public string Name { get; set; }
        public CharacterType Character { get; set; }
        public SpriteChar Target { get; set; }

        // Параметры (здоровье, одежда, урон, броня и т.д.)
        // Инвентарь с предметами дропа

    }

}
