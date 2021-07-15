using System;


namespace Engine.Data
{

    public class Skillet : NPC
    {

        public Skillet()
        {
            ID = "npc/skillet";
            Name = "Скелет";
            Character = CharacterType.Barbarian;

            Characteristics = new Characteristics()
            {
                BaseDefence = 1,
                BaseDamage = 1,
                MaxHealth = 20,
                Health = 20,
            };

            Armor = null;
            Weapon = new BrokenBone();

            MoveRadius = 4;
            AgressionRadius = 4;
        }

    }

}
