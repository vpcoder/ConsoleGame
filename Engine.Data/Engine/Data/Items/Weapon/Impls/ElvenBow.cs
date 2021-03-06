
namespace Engine.Data
{

    public class ElvenBow : RangedWeapon
    {

        public ElvenBow()
        {
            this.Bullet = typeof(IArrow); // стреляет стрелами

            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 10;

            this.ID = "item/weapon/elvenbow";
            this.Distance = 4;

            this.Title = "Эльфийский лук";
            this.Description = "Дальнобойное оружие со средним уроном";

            this.UseInterval = 1000; // Раз в 1 секунду
        }

    }

}
