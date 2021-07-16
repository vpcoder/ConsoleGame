using System;


namespace Engine.Data
{

    /// <summary>
    /// Базовый класс снаряда
    /// </summary>
    public abstract class Bullet : Item, IBullet
    {

        /// <summary>
        /// Урон снаряда
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Направление движения снаряда
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Пройденный снарядом путь
        /// </summary>
        public int MovePath { get; set; }

        /// <summary>
        /// Максимальная дальность снаряда
        /// </summary>
        public int MoveMaxPath { get; set; }

    }

}
