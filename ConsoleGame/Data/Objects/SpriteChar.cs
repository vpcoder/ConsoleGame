using System;
using System.Drawing;

namespace Engine.Data
{

    /// <summary>
    /// Базовый класс для описания символа в консоли - любого видимого объекта в игре
    /// </summary>
    public abstract class SpriteChar
    {

        /// <summary>
        /// Символ, которым изображён объект в мире
        /// </summary>
        public virtual char Symbol { get; set; }

        /// <summary>
        /// Цвет символа
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// Положение объекта в мире по X
        /// </summary>
        public virtual int PosX { get; set; }

        /// <summary>
        /// Положение объекта в мире по Y
        /// </summary>
        public virtual int PosY { get; set; }

    }

}