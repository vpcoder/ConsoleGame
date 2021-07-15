
namespace Engine.Data
{

    public class ElvenBow : RangedWeapon
    {

        public ElvenBow()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 10;

            this.ID = "item/weapon/elvenbow";
            this.Distance = 10;

            this.Title = "Эльфийский лук";
            this.Description = "Дальнобойное оружие со средним уроном";
        }

    }

}
