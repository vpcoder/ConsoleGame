
namespace Engine.Data
{

    public abstract class UsedItem : Item, IUsedItem
    {

        public abstract void Use(World world);

    }

}
