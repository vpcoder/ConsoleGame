using System;
using System.Drawing;

namespace Engine.Data
{
    class PowerPotion : UsedItem
    {
        public PowerPotion()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 10;
            this.StackSize = 1;
            this.ID = "item/used/powerpotion";

            this.Title = "Зелье силы";
            this.Description = "Увеличивает силу атаки на 10ед.";
        }

        public override void Use(World world)
        {
            var param = world.Player.Characteristics;
            param.AddBuff(new Buff(1) { Duration = 100, AdditionalDamage = 10 });
        }
    }
}
