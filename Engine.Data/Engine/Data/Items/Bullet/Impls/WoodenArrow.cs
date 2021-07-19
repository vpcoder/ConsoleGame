
namespace Engine.Data
{

    public class WoodenArrow : Bullet, IArrow
    {

        public WoodenArrow()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 30;
            this.StackSize = 1;

            this.ID = "item/bullet/woodenarrow";

            this.Title = "Деревянная стрела";
            this.Description = "Простая стрела из дерева";

            this.Damage = 1;
        }

    }

}
