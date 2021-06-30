using System;

namespace Engine.Data
{
    class SunlightSpear : RangedWeapon
    {
        public SunlightSpear()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 30;
            this.Symbol = '/';
            this.Color = ConsoleColor.Green;
            this.Distance = 10;

            this.Title = "Копьё Света";
            this.Description = "Копьё выкаванное из осветлённого золота";
        }
    }
}
