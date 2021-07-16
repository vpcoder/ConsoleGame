
using System;

namespace Engine.Data
{

    /// <summary>
    /// Оружие дальнего боя
    /// </summary>
    public interface IWeaponRanged
    {

        /// <summary>
        /// Снаряд, которым стреляет это оружие
        /// </summary>
        Type Bullet { get; set; }

        /// <summary>
        /// Частота стрельбы из оружия
        /// </summary>
        long ShootInterval { get; set; }

        /// <summary>
        /// Время последнего выстрела из этого оружия
        /// </summary>
        long LastShoot { get; set; }

        /// <summary>
        /// Дальность снарядов
        /// </summary>
        int Distance { get; set; }

    }

}
