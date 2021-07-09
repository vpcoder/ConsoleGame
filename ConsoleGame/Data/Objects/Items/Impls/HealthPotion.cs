using System;
using System.Drawing;

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
            this.Color        = Color.Red;
            this.Title        = "Зелье здоровья";
            this.Description  = "Восстанавливает здоровье на 10ед.";
        }

        public override void Use(World world)
        {
            
            world.Player.HP += 10;
            if (world.Player.HP > world.Player.MaxHP)
            {
                world.Player.HP = world.Player.MaxHP;
            }

        }

    }

}

