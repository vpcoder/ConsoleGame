using System;
using System.Drawing;

namespace Engine.Data
{
    class Apple : UsedItem
    {
        public Apple()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 10;
            this.StackSize = 1;
            this.ID = "item/used/apple";
            this.Color = Color.Red;
            this.Title = "Яблоко";
            this.Description = "Большое сладкое яблоко, налитое соком";
        }

        public override void Use(World world)
        {

            world.Player.HP += 5;
            if (world.Player.HP > world.Player.MaxHP)
            {
                world.Player.HP = world.Player.MaxHP;
            }

        }
    }
}
