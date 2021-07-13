using System;

namespace Engine.Data
{

    public class HealtPotion : UsedItem
    {

        public HealtPotion()
        {
            this.IsQuestItem  = false;
            this.MaxStackSize = 10;
            this.StackSize    = 1;
            this.ID = "item/used/healtpotion";
            this.Title        = "Зелье здоровья";
            this.Description  = "Восстанавливает здоровье на 10ед.";
        }

        public override void Use(World world)
        {
            var param = world.Player.Characteristics;
            param.Health = Math.Max(param.Health + 10, param.MaxHealth);
        }

    }

}

