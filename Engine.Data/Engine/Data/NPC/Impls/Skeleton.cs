
namespace Engine.Data
{

    public class Skeleton : NPC
    {

        public Skeleton()
        {
            ID = "npc/skeleton";
            Name = "Скелет";
            CharacterType = CharacterType.Barbarian;

            Characteristics = new Characteristics()
            {
                BaseDefence = 1,
                BaseDamage = 1,
                MaxHealth = 5,
                Health = 5,
            };

            Armor = null;
            Weapon = new BrokenBone();

            //Inventory.TryAddItem(new ElvenBow());
            //Inventory.TryAddItem(new WoodenArrow(), 30);
            //Inventory.TryAddItem(new WoodenArrow(), 30);

            MoveRadius = 4;
            AgressionRadius = 4;
        }

    }

}
