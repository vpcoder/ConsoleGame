using System;

namespace Engine.Data
{

    public class PowerFruit : UsedItem
    {

        public PowerFruit()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 10;
            this.StackSize = 1;
            this.ID = "item/used/powerfruit";
            this.Title = "Плод Древа силы";
            this.Description = "Этот фрукт выглядит очень странно...";
        }

        public override void Use(World world)
        {
            var param = world.Player.Characteristics;
            param.Health = Math.Max(param.Health + 5, param.MaxHealth);
            param.AddBuff(new Buff(2) { Duration = 100, AdditionalDamage = 5 });

        }

    }

}
