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
        public int HP { get; set; } = 60;

        /// <summary>
        /// Максимальное здоровье персонажа
        /// </summary>

        public int MaxHP { get; set; } = 100;

        /// <summary>
        /// Оружие
        /// </summary>
        public Weapon Weapon { get; set; } = null;





        // РЕАЛИЗОВАТЬ 
        public int Damage { get; }
        public int Defence { get; }





        /// <summary>
        /// Броня персонажа
        /// </summary>
        public Armor Armor { get; set; } = null;

        /// <summary>
        /// Инвентарь
        /// </summary>
        public Inventory Inventory { get; set; } = new Inventory();

    }

}
