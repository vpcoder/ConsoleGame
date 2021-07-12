
namespace Engine.Data
{

    /// <summary>
    /// Интерфейс спрайта
    /// </summary>
    public interface ISprite
    {

        /// <summary>
        /// Символ, которым изображён объект в мире
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// Положение объекта в мире по X
        /// </summary>
        int PosX { get; set; }

        /// <summary>
        /// Положение объекта в мире по Y
        /// </summary>
        int PosY { get; set; }

    }

}
