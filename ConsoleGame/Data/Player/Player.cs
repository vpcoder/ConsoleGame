using System;

namespace Engine.Data
{

    /// <summary>
    /// Базовый класс игрока
    /// </summary>
    public class Player : SpriteChar
    {

        public Player()
        {
            this.Color  = ConsoleColor.White;
            this.Symbol = '☺';
        }

        /// <summary>
        /// Здоровье персонажа
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Урон персонажа
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Защита персонажа
        /// </summary>
        public int Armor { get; set; }

    }

}
