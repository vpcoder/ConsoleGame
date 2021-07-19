using System;

namespace Engine.Data
{

    /// <summary>
    /// Оружие дальнего боя
    /// </summary>
    public interface IWeaponRanged : IWeapon
    {

        /// <summary>
        /// Снаряд, которым стреляет это оружие
        /// </summary>
        Type Bullet { get; set; }

        /// <summary>
        /// Дальность снарядов
        /// </summary>
        int Distance { get; set; }

    }

}
