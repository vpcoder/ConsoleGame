
using System;

namespace Engine.Data
{

    /// <summary>
    /// Базовый класс оружия дальнего боя
    /// </summary>
    public abstract class RangedWeapon : Weapon, IWeaponRanged
    {

        /// <summary>
        /// Снаряд, которым стреляет это оружие
        /// </summary>
        public Type Bullet { get; set; }

        /// <summary>
        /// Дальность снарядов
        /// </summary>
        public int Distance { get; set; }

    }

}
