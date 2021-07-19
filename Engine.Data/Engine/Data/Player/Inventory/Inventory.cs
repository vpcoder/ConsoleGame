using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Data
{

    /// <summary>
    /// Инвентарь
    /// </summary>
    public class Inventory : IInventory
    {

        private const int INVENTORY_MAX_SIZE = 20;

        private IItem[] items { get; set; } = new IItem[INVENTORY_MAX_SIZE];

        /// <summary>
        /// Размер инвентаря
        /// </summary>
        public int InventoryMaxSize
        {
            get
            {
                return INVENTORY_MAX_SIZE;
            }
        }

        /// <summary>
        /// Предметы инвентаря
        /// </summary>
        public IEnumerable<IItem> Items { get { return items; } }

        /// <summary>
        /// Индекс выбранного предмета
        /// </summary>
        public int SelectedIndex { get; set; } = 0;

        /// <summary>
        /// Выбранный предмет
        /// </summary>
        public IItem Selected { get { return items[SelectedIndex]; } set { items[SelectedIndex] = value; } }

        /// <summary>
        /// Ищет и возвращает первый элемент в инвентаре, который соответствует типу Type
        /// </summary>
        /// <param name="type">тип искомого предмета в инвентаре</param>
        /// <returns>Возвращает первый элемент в инвентаре, который соответствует типу Type</returns>
        public IItem GetFirstByType(Type type)
        {
            return Items.Where(o => o != null && (type == o.GetType() || type.IsAssignableFrom(o.GetType()))).FirstOrDefault();
        }

        /// <summary>
        /// Ищет и возвращает первый элемент в инвентаре, который соответствует типу T
        /// </summary>
        /// <typeparam name="T">тип искомого предмета в инвентаре</typeparam>
        /// <returns>Возвращает первый элемент в инвентаре, который соответствует типу T</returns>
        public T GetFirstByType<T>() where T : class, IItem
        {
            return (T)GetFirstByType(typeof(T));
        }


        /// <summary>
        /// Ищет и возвращает элементы в инвентаре, которые соответствует типу type
        /// </summary>
        /// <param name="type">тип искомого предмета в инвентаре</param>
        /// <returns>Возвращает элементы в инвентаре, которые соответствует типу type</returns>
        public ICollection<IItem> GetByType(Type type)
        {
            return Items.Where(o => o != null && (type == o.GetType() || type.IsAssignableFrom(o.GetType()))).ToList();
        }

        /// <summary>
        /// Ищет и возвращает элементы в инвентаре, которые соответствует типу T
        /// </summary>
        /// <typeparam name="T">тип искомого предмета в инвентаре</typeparam>
        /// <returns>Возвращает элементы в инвентаре, которые соответствует типу T</returns>
        public ICollection<T> GetByType<T>() where T : class, IItem
        {
            return Items.Where(o => o != null && (typeof(T) == o.GetType() || typeof(T).IsAssignableFrom(o.GetType()))).Select(o => o as T).ToList();
        }

        /// <summary>
        /// Добавляет предмет в инвентарь
        /// </summary>
        /// <param name="item">Добавляемый предмет</param>
        /// <param name="count">Число добавляемых предметов (если не задано - берётся из item)</param>
        /// <returns>Возвращает true - если предмет успешно добавлен в инвентарь, и false - если предмет не удалось добавить (инвентарь переполнен)</returns>
        public bool TryAddItem(IItem item, int count = -1)
        {
            count = count == -1 ? item.StackSize : count;

            IList<int> emptySlots = new List<int>();

            for (int i = 0; i < InventoryMaxSize; i++)
            {
                IItem tmpItem = items[i];
                if(tmpItem == null)
                {
                    emptySlots.Add(i);
                    continue;
                }

                if(tmpItem.GetType().Equals(item.GetType()) && tmpItem.StackSize < tmpItem.MaxStackSize && count > 0) // Однотипные предметы, и в инвентаре предмет не полностью укомплектован копиями
                {
                    var freeStack = tmpItem.MaxStackSize - tmpItem.StackSize; // Сколько предметов мы можем доложить?
                    if(count <= freeStack)
                    {
                        tmpItem.StackSize += count;
                        count = 0;
                    }
                    else
                    { // Предметов слишком много, нужно разложить на остальные слоты тоже
                        tmpItem.StackSize += freeStack;
                        count -= freeStack;
                    }
                }

                if (count == 0) // Все предметы положили?
                    return true;
            }

            if(count > 0) // Ещё есть часть предметов, которые не удалось положить в первый проход
            {
                if(emptySlots.Count == 0) // Свободных слотов нет
                    return false;

                items[emptySlots[0]] = item;
                item.StackSize = Math.Min(count, item.MaxStackSize);
            }

            return true;
        }

        /// <summary>
        /// Удаляет указанный предмет по ссылке из инвентаря
        /// </summary>
        /// <param name="item">Ссылка на предмет в инвентаре</param>
        public void RemoveItem(IItem item)
        {
            for (int i = 0; i < InventoryMaxSize; i++)
            {
                if (items[i] == item)
                {
                    items[i] = null;
                    return;
                }
            }
        }

        /// <summary>
        /// Удаляет из инвентаря указанное количество предметов определённого типа
        /// </summary>
        /// <param name="type">Удаляемый предмет</param>
        /// <param name="count">Число удаляемых копий предмета (если не задано - удаляет ВСЕ)</param>
        /// <returns></returns>
        public bool TryRemoveItem(Type type, int count = -1)
        {
            for (int i = 0; i < InventoryMaxSize; i++)
            {
                IItem tmpItem = items[i];
                if (tmpItem == null)
                    continue;

                if (tmpItem.GetType().Equals(type)) // Однотипные предметы
                {
                    if(count == -1)
                    {
                        items[i] = null;
                        return true;
                    }
                    if (count > 0)
                    {
                        if(tmpItem.StackSize >= count)
                        {
                            tmpItem.StackSize -= count;
                            return true;
                        }
                        else
                        {
                            count -= tmpItem.StackSize;
                            tmpItem.StackSize = 0;
                        }
                    }
                }
                if (count == 0)
                    return true;
            }
            return count == 0;
        }

        /// <summary>
        /// Удаляет из инвентаря указанное количество предметов определённого типа
        /// </summary>
        /// <typeparam name="T">Удаляемый предмет</typeparam>
        /// <param name="count">Число удаляемых копий предмета (если не задано - удаляет ВСЕ)</param>
        /// <returns></returns>
        public bool TryRemoveItem<T>(int count = -1)
        {
            return TryRemoveItem(typeof(T), count);
        }

    }

}
