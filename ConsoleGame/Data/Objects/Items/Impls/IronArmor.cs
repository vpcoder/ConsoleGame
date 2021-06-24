using System;


namespace Engine.Data
{
    public class IronArmor : Armor
    {
        public IronArmor()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Color = ConsoleColor.Blue;
            this.Symbol = '₩';
            this.Defence = 8;

            this.Title = "Железная броня";
            this.Description = "Стандартная броня из железа";
        }
    }
}
