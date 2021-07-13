
namespace Engine.Data
{

    /// <summary>
    /// Базовый класс для описания спрайта
    /// </summary>
    public abstract class Sprite : ISprite
    {

        /// <summary>
        /// Символ, которым изображён объект в мире
        /// </summary>
        public virtual string ID { get; set; }

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