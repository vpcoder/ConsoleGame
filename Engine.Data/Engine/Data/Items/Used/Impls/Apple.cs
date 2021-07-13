using System;

namespace Engine.Data
{
    public class Apple : UsedItem
    {

        public Apple()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 10;
            this.StackSize = 1;
            this.ID = "item/used/apple";
            this.Title = "Яблоко";
            this.Description = "Большое сладкое яблоко, налитое соком";
        }

        public override void Use(World world)
        {
            var param = world.Player.Characteristics;
            param.Health = Math.Max(param.Health + 5, param.MaxHealth);
        }

    }

}
