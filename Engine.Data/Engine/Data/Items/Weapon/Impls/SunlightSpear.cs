
namespace Engine.Data
{
    public class SunlightSpear : RangedWeapon
    {
        public SunlightSpear()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 30;
            this.ID = "item/weapon/sunlightspear";
            this.Distance = 10;

            this.Title = "Копьё Света";

            this.Description = "Копьё, выкованное из осветлённого золота";


            UseInterval = 2000;
        }
    }
}
