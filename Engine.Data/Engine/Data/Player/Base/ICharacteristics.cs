using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Характеристики
    /// </summary>
    public interface ICharacteristics
    {

        /// <summary>
        /// Здоровье
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        int MaxHealth { get; set; }

        /// <summary>
        /// Персонаж умер
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Базовая атака
        /// </summary>
        int BaseDamage { get; set; }

        /// <summary>
        /// Базовая защита
        /// </summary>
        int BaseDefence { get; set; }

        /// <summary>
        /// Баффы
        /// </summary>
        ICollection<IBuff> CurrentBuffs { get; }

        /// <summary>
        /// Добавляем бафф
        /// </summary>
        /// <param name="buff"></param>
        void AddBuff(IBuff buff);

    }

}
