
namespace Engine.Data
{

    public interface IArmor
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

        /// <summary>
        /// Параметр защиты брони
        /// </summary>
        int Defence { get; set; }

        /// <summary>
        /// Является ли предмет квестовым предметом?
        /// </summary>
        bool IsQuestItem { get; set; }

        /// <summary>
        /// Текущий размер пачки
        /// </summary>
        int StackSize { get; set; }

        /// <summary>
        /// Максимальный размер пачки
        /// </summary>
        int MaxStackSize { get; set; }

        /// <summary>
        /// Название предмета
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Описание предмета
        /// </summary>
        string Description { get; set; }

    }

}
