using System;
using System.Drawing;

namespace Engine.Data
{

    public class IronSword : MeleeWeapon
    {

        public IronSword()
        {
            this.IsQuestItem  = false;
            this.MaxStackSize = 1;
            this.StackSize    = 1;
            this.Damage       = 1;
            this.Symbol       = '†';
            this.Color        = Color.Gray;

            this.Title        = "Железный меч";
            this.Description  = "Простейший меч из железа";
        }

    }

}

