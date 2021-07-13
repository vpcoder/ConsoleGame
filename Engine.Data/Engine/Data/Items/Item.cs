
namespace Engine.Data
{

    /// <summary>
    /// Абстрактный предмет
    /// </summary>
    public abstract class Item : Sprite, IItem
    {

        /// <summary>
        /// Является ли предмет квестовым предметом?
        /// </summary>
        public bool IsQuestItem { get; set; }

        /// <summary>
        /// Текущий размер пачки
        /// </summary>
        public int StackSize { get; set; }

        /// <summary>
        /// Максимальный размер пачки
        /// </summary>
        public int MaxStackSize { get; set; }

        /// <summary>
        /// Название предмета
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание предмета
        /// </summary>
        public string Description { get; set; }

    }

}
