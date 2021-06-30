﻿using System;

namespace Engine.Data
{
    class DavidsSling : RangedWeapon
    {
        public DavidsSling()
        {
            this.IsQuestItem = false;
            this.MaxStackSize = 1;
            this.StackSize = 1;
            this.Damage = 30;
            this.Symbol = '/';
            this.Color = ConsoleColor.Green;
            this.Distance = 5;

            this.Title = "Праща Давида";
            this.Description = "Мощное, но недальнобойное оружие";
        }
    }
}
