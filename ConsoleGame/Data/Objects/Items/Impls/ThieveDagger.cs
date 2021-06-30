using System;

namespace Engine.Data
{
    public class ThieveDagger : MeleeWeapon
    {
        public ThieveDagger()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 15;
            this.Symbol = '†';
            this.Color = ConsoleColor.Blue;

            this.Title = "Воровской кинжал";
            this.Description = "\"Месть Марии\" - Кинжал воров из корабельных доков";
        }
    }
}
