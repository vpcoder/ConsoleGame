
namespace Engine.Data
{

    public class Skeleton : NPC
    {

        public Skeleton()
        {
            ID = "npc/skeleton";
            Name = "Скелет";
            Character = CharacterType.Barbarian;

            Characteristics = new Characteristics()
            {
                BaseDefence = 1,
                BaseDamage = 1,
                MaxHealth = 5,
                Health = 5,
            };

            Armor = null;
            Weapon = new BrokenBone();

            MoveRadius = 4;
            AgressionRadius = 4;
        }

    }

}
