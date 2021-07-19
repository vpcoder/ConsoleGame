
using System;
using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Инвентарь
    /// </summary>
    public interface IInventory
    {

        /// <summary>
        /// Размер инвентаря
        /// </summary>
        int InventoryMaxSize { get; }

        /// <summary>
        /// Предметы инвентаря
        /// </summary>
        IEnumerable<IItem> Items { get; }

        /// <summary>
        /// Индекс выбранного предмета
        /// </summary>
        int SelectedIndex { get; set; }

        /// <summary>
        /// Выбранный предмет
        /// </summary>
        IItem Selected { get; set; }

        /// <summary>
        /// Ищет и возвращает первый элемент в инвентаре, который соответствует типу type
        /// </summary>
        /// <param name="type">тип искомого предмета в инвентаре</param>
        /// <returns>Возвращает первый элемент в инвентаре, который соответствует типу Type</returns>
        IItem GetFirstByType(Type type);

        /// <summary>
        /// Ищет и возвращает первый элемент в инвентаре, который соответствует типу T
        /// </summary>
        /// <typeparam name="T">тип искомого предмета в инвентаре</typeparam>
        /// <returns>Возвращает первый элемент в инвентаре, который соответствует типу T</returns>
        T GetFirstByType<T>() where T : class, IItem;

        /// <summary>
        /// Ищет и возвращает элементы в инвентаре, которые соответствует типу type
        /// </summary>
        /// <param name="type">тип искомого предмета в инвентаре</param>
        /// <returns>Возвращает элементы в инвентаре, которые соответствует типу type</returns>
        ICollection<IItem> GetByType(Type type);

        /// <summary>
        /// Ищет и возвращает элементы в инвентаре, которые соответствует типу T
        /// </summary>
        /// <typeparam name="T">тип искомого предмета в инвентаре</typeparam>
        /// <returns>Возвращает элементы в инвентаре, которые соответствует типу T</returns>
        ICollection<T> GetByType<T>() where T : class, IItem;

        /// <summary>
        /// Добавляет предмет в инвентарь
        /// </summary>
        /// <param name="item">Добавляемый предмет</param>
        /// <param name="count">Число добавляемых предметов (если не задано - берётся из item)</param>
        /// <returns>Возвращает true - если предмет успешно добавлен в инвентарь, и false - если предмет не удалось добавить (инвентарь переполнен)</returns>
        bool TryAddItem(IItem item, int count = -1);

        /// <summary>
        /// Удаляет указанный предмет по ссылке из инвентаря
        /// </summary>
        /// <param name="item">Ссылка на предмет в инвентаре</param>
        void RemoveItem(IItem item);

        /// <summary>
        /// Удаляет из инвентаря указанное количество предметов определённого типа
        /// </summary>
        /// <param name="type">Удаляемый предмет</typeparam>
        /// <param name="count">Число удаляемых копий предмета (если не задано - удаляет ВСЕ)</param>
        /// <returns>Возвращает true - если предмет успешно удалён из инвентаря, и false - если предмет не удалось удалить (в инвентаре не нашлось нужное количество предметов, или не нашёлся сам предмет)</returns>
        bool TryRemoveItem(Type type, int count);

        /// <summary>
        /// Удаляет из инвентаря указанное количество предметов определённого типа
        /// </summary>
        /// <typeparam name="T">Удаляемый предмет</typeparam>
        /// <param name="count">Число удаляемых копий предмета (если не задано - удаляет ВСЕ)</param>
        /// <returns>Возвращает true - если предмет успешно удалён из инвентаря, и false - если предмет не удалось удалить (в инвентаре не нашлось нужное количество предметов, или не нашёлся сам предмет)</returns>
        bool TryRemoveItem<T>(int count = -1);

    }

}
