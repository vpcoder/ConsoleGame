using System;


namespace Engine.Data
{
    public class ClothArmor : Armor
    {
        public ClothArmor()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Color = ConsoleColor.Gray;
            this.Symbol = '∬';
            this.Defence = 2;

            this.Title = "Тканевая броня";
            this.Description = "Обычная юроня из ткани";
        }
    }
}
