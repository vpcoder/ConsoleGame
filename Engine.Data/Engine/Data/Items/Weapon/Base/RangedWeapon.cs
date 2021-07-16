
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

        /// <summary>
        /// Частота стрельбы из оружия
        /// </summary>
        public long ShootInterval { get; set; }

        /// <summary>
        /// Время последнего выстрела из этого оружия
        /// </summary>
        public long LastShoot { get; set; }

    }

}
