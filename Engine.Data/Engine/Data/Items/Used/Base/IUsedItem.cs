
namespace Engine.Data
{

    /// <summary>
    /// Используемый предмет
    /// </summary>
    public interface IUsedItem : IItem
    {

        /// <summary>
        /// Метод использования предмета
        /// </summary>
        /// <param name="world">Мир, в котором используется предмет</param>
        void Use(World world);

    }

}
