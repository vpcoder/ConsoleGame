
namespace Engine.Data
{

    /// <summary>
    /// Базоывай класс статических объектов в мире
    /// </summary>
    public abstract class Object : SpriteChar
    {

        /// <summary>
        /// Свойство определяющее - можно ли ходить по объекту или нет?
        /// </summary>
        public virtual bool Walkable { get; set; } = true;

    }

}
