using System;


namespace Engine.Data
{

    public abstract class NPC : Character, INPC
    {

        public string Name { get; set; }
        public CharacterType Character { get; set; }
        public Sprite Target { get; set; }

        // Параметры (здоровье, одежда, урон, броня и т.д.)
        // Инвентарь с предметами дропа

    }

}
