
namespace Engine.Data
{
    public class BrokenBone : MeleeWeapon
    {
        public BrokenBone()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 5;

            this.ID = "item/weapon/brokenbone";

            this.Title = "Сломаная кость";
            this.Description = "Фрагмент человеческой кости";

            UseInterval = 1200;
        }
    }
}
