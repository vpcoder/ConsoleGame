using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Data;

namespace Engine.Editor
{

    public enum ObjectType : int
    {
        Tile    = 0x00,
        Item    = 0x01,
        NPC     = 0x02,

        Unknown = 0xff,
    };

    /// <summary>
    /// Сервис доступа к коллекциям объектов игры
    /// </summary>
    public class ObjectProviderService
    {

        #region Singleton

        private static Lazy<ObjectProviderService> instance = new Lazy<ObjectProviderService>(() => new ObjectProviderService());

        public static ObjectProviderService Instance { get { return instance.Value; } }

        #endregion

        private IDictionary<ObjectType, ICollection<object>> data = new Dictionary<ObjectType, ICollection<object>>();
        private IDictionary<string, object> nameToInstanceData = new Dictionary<string, object>();

        private ObjectProviderService()
        {
            foreach(ObjectType type in Enum.GetValues(typeof(ObjectType)))
                data.Add(type, new List<object>(100));

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) // получаем и перебираем все библиотеки в проекте
            { 
                foreach(var type in assembly.GetTypes()) // получаем и перебираем все классы/интерфейсы и прочие бъекты в каждой из найденных библиотек
                {
                    if (!typeof(ISprite).IsAssignableFrom(type)) // Класс который мы нашли - не является ISprite
                        continue;

                    if (type.IsAbstract) // Класс что мы нашли - не является реализацией
                        continue;

                    var objectType = getObjectTypeByClass(type); // Определяем группу объекта (тайл, предмет, НПС и т.д.)
                    var instance = Activator.CreateInstance(type); // Создаём один экземпляр этого объекта
                    nameToInstanceData[instance.GetType().FullName] = instance; // Записываем экземпляр объекта по имени
                    data[objectType].Add(instance); // Добавляем объект в нашу глобальную коллекцию всех предметов игры
                }
            }
        }

        /// <summary>
        /// Получает группу по классу
        /// </summary>
        /// <param name="type">класс, по которому нужно определить в какой группе объект</param>
        /// <returns>Возвращает группу</returns>
        private ObjectType getObjectTypeByClass(Type type)
        {
            if(typeof(IItem).IsAssignableFrom(type)) // Это предмет?
            {
                return ObjectType.Item;
            }

            if(typeof(IObject).IsAssignableFrom(type))
            {
                return ObjectType.Tile;
            }

            if (typeof(INPC).IsAssignableFrom(type))
            {
                return ObjectType.NPC;
            }

            return ObjectType.Unknown;
        }

        /// <summary>
        /// Возвращает множество объектов скастованных к T находящихся в группе objectType, которые мы нашли в игре
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых объектов</typeparam>
        /// <param name="objectType">Группа искомых объектов</param>
        /// <returns>Возвращает множество объектов скастованных к T находящихся в группе objectType, которые мы нашли в игре</returns>
        public ICollection<T> Get<T>(ObjectType objectType) where T: class, ISprite
        {
            return data[objectType].Select(o => o as T).ToList();
        }

        /// <summary>
        /// Возвращает экземпляр объекта по имени
        /// </summary>
        /// <typeparam name="T">Приведение найденого объекта к указанному типу</typeparam>
        /// <param name="fullName">Полное имя класса</param>
        /// <returns>Возвращает экземпляр объекта по имени</returns>
        public T GetByName<T>(string fullName) where T : class, ISprite
        {
            return (T)nameToInstanceData[fullName];
        }

    }

}
