using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Характеристики
    /// </summary>
    public class Characteristics
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
        public HashSet<Buff> CurrentBuffs = new HashSet<Buff>();

        /// <summary>
        /// Добавляем бафф
        /// </summary>
        /// <param name="buff"></param>
        public void AddBuff(Buff buff)
        {
            CurrentBuffs.Add(buff);
        }

    }

}
