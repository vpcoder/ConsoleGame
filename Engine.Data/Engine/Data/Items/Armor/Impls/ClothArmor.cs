
namespace Engine.Data
{
    public class ClothArmor : Armor
    {
        public ClothArmor()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;

            this.ID = "item/armor/clotharmor";
            this.Defence = 2;

            this.Title = "Тканевая броня";
            this.Description = "Обычная броня из ткани";
        }
    }
}
