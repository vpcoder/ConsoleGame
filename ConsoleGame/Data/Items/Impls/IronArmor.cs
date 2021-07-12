using System;
using System.Drawing;

namespace Engine.Data
{
    public class IronArmor : Armor
    {
        public IronArmor()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.ID = "item/armor/ironarmor";
            this.Defence = 8;

            this.Title = "Железная броня";
            this.Description = "Стандартная броня из железа";
        }
    }
}
