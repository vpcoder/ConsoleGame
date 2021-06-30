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
            this.Symbol       = 'b';
            this.Color        = ConsoleColor.Red;
            this.Title        = "Зелье здоровья";
            this.Description  = "Повышает здоровье на 10ед.";
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

