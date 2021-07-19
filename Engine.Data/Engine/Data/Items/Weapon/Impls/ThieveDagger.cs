
namespace Engine.Data
{
    public class ThieveDagger : MeleeWeapon
    {
        public ThieveDagger()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 10;
            this.ID = "item/weapon/thievedagger";

            this.Title = "Воровской кинжал";
            this.Description = "\"Месть Марии\" - Кинжал воров из корабельных доков";

            UseInterval = 700;
        }
    }
}
