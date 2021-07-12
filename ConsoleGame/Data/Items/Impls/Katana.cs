using System;
using System.Drawing;

namespace Engine.Data
{
    public class Katana : MeleeWeapon
    {
        public Katana()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 30;
            this.ID = "item/weapon/katana";

            this.Title = "Катана";
            this.Description = "Кровавый привет из Японии";
        }
    }
}
