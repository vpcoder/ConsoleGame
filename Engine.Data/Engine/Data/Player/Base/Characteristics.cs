using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Характеристики
    /// </summary>
    public class Characteristics : ICharacteristics
    {

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health { get; set; } = 60;

        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public int MaxHealth { get; set; } = 100;

        /// <summary>
        /// Базовый урон
        /// </summary>
        public int BaseDamage { get; set; } = 0;

        /// <summary>
        /// Базовая защита
        /// </summary>
        public int BaseDefence { get; set; } = 0;

        /// <summary>
        /// Персонаж умер
        /// </summary>
        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }

        /// <summary>
        /// Баффы
        /// </summary>
        public ICollection<IBuff> CurrentBuffs { get; } = new HashSet<IBuff>();

        /// <summary>
        /// Добавляем бафф
        /// </summary>
        /// <param name="buff"></param>
        public void AddBuff(IBuff buff)
        {
            CurrentBuffs.Add(buff);
        }

    }

}
