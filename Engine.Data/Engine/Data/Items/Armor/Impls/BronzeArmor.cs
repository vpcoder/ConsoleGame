
namespace Engine.Data
{
    public class BronzeArmor : Armor
    {
        public BronzeArmor()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.ID = "item/armor/bronzearmor";
            this.Defence = 5;

            this.Title = "Бронзовая броня";
            this.Description = "Крепкая броня из бронзы";
        }
    }
}
