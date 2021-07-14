
namespace Engine.Data
{

    public interface IObject : ISprite
    {

        /// <summary>
        /// Свойство определяющее - можно ли ходить по объекту или нет?
        /// </summary>
        bool Walkable { get; set; }

    }

}
