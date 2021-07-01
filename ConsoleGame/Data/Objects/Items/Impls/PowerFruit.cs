using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Data
{
    class PowerFruit: UsedItem
    {   public PowerFruit()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 10;
            this.StackSize = 1;
            this.Symbol = 'Ѡ';
            this.Color = ConsoleColor.DarkCyan;
            this.Title = "Плод Древа силы";
            this.Description = "Этот фрукт выглядит очень странно...";
        }

        public override void Use(World world)
        {

            world.Player.HP += 5;
            if (world.Player.HP > world.Player.MaxHP)
            {
                world.Player.HP = world.Player.MaxHP;
            }

            world.Player.AddBuff(new Buff(2) { Duration = 100, AdditionalDamage = 5 });

        }
    }
}
