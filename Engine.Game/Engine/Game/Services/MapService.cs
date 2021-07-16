using Engine.Data;
using Engine.Data.Impls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Engine.Services
{

    [Serializable]
    public class MapHeader
    {
        public string Name { get; set; }

        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public int PlayerPosX { get; set; }
        public int PlayerPosY { get; set; }
    }

    [Serializable]
    public class NpcItem
    {
        public Type Type { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }

    [Serializable]
    public class MapBody
    {
        public Type[][,] Data { get; set; }
        public NpcItem[] NPCs { get; set; }
    }

    /// <summary>
    /// Сервис работы с картами
    /// </summary>
    public class MapService
    {

        #region Singleton

        private static Lazy<MapService> instance = new Lazy<MapService>(() => new MapService());

        public static MapService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private MapService() { }

        #endregion

        /// <summary>
        /// Сохраняет наш мир в файл
        /// </summary>
        /// <param name="map">Мир, который нужно сохранить</param>
        /// <param name="mapName">Имя файла, в который нужно сохранить мир</param>
        public void Save(World world, string mapName)
        {
            var map = world.Map;
            var serializator = new BinaryFormatter();

            var header = new MapHeader();
            header.Name = map.Name;
            header.SizeX = map.SizeX;
            header.SizeY = map.SizeY;
            header.PlayerPosX = map.PlayerStartPosX;
            header.PlayerPosY = map.PlayerStartPosY;

            using (var stream = new StreamWriter(new FileStream(mapName, FileMode.CreateNew)))
            {
                serializator.Serialize(stream.BaseStream, header); // Записываем заголовок карты
                serializator.Serialize(stream.BaseStream, ToBody(world)); // Записываем мир
            }
        }

        /// <summary>
        /// Вытаскивает матрицу карты, преобразуя в тело для записи в файл
        /// </summary>
        /// <param name="world">Мир</param>
        /// <returns>Тело карты для записи в файл</returns>
        private MapBody ToBody(World world)
        {
            var map = world.Map;
            var body = new MapBody();
            body.Data = new Type[map.LayoutCount][,];
            for(int layout = 0; layout < map.LayoutCount; layout++)
            {
                body.Data[layout] = new Type[map.SizeX, map.SizeY];
                for (int y = 0; y< map.SizeY; y++)
                {
                    for (int x = 0; x < map.SizeX; x++)
                    {
                        var sprite = map.Get(layout, x, y);
                        body.Data[layout][x, y] = sprite?.GetType() ?? null;
                    }
                }
            }
            body.NPCs = new NpcItem[world.NPCs.Count];
            int index = 0;
            foreach (var npc in world.NPCs)
            {
                var item = new NpcItem();
                body.NPCs[index++] = item;
                item.PosX = npc.PosX;
                item.PosY = npc.PosY;
                item.Type = npc.GetType();
            }
            return body;
        }

        /// <summary>
        /// Выполняет запись объектов из тела карты в карту
        /// </summary>
        /// <param name="body">Тело карты из файла</param>
        /// <param name="map">Карта</param>
        private void WriteFromBody(MapBody body, Map map)
        {
            for (int layout = 0; layout < map.LayoutCount; layout++)
            {
                for (int y = 0; y < map.SizeY; y++)
                {
                    for (int x = 0; x < map.SizeX; x++)
                    {
                        var type = body.Data[layout][x, y];
                        if(type == null)
                        {
                            map.Set(null, layout, x, y); // В этой точке ничего нет, так и запишем в карту
                            continue;
                        }
                        var instance = (ISprite)Activator.CreateInstance(type);
                        map.Set(instance, layout, x, y);
                        PostCreateSprite(instance);
                    }
                }
            }
        }

        /// <summary>
        /// Загружает нашу карту из файла в мир
        /// </summary>
        /// <param name="mapName">Файл мира, который нужно загрузить</param>
        /// <param name="world">Объект мира, куда нужно записать прочитаную карту</param>
        public void Load(string mapName, World world)
        {
            Map map = null;
            MapBody body;
            var serializator = new BinaryFormatter();

            using (var stream = new StreamReader(new FileStream(mapName, FileMode.Open)))
            {
                var header = (MapHeader)serializator.Deserialize(stream.BaseStream); // Читаем заголовок карты
                map = new Map(header.SizeX, header.SizeY);
                map.Name = header.Name;
                map.PlayerStartPosX = header.PlayerPosX;
                map.PlayerStartPosY = header.PlayerPosY;

                body = (MapBody)serializator.Deserialize(stream.BaseStream); // Читаем тело карты
                WriteFromBody(body, map);
            }

            world.Player.PosX = map.PlayerStartPosX;
            world.Player.PosY = map.PlayerStartPosY;

            world.Map.ResizeFrom(map);

            foreach(var npcData in body.NPCs) // Перебираем все объекты в мире
            {
                var npc = (INPC)Activator.CreateInstance(npcData.Type);
                npc.PosX = npcData.PosX;
                npc.PosY = npcData.PosY;
                world.NPCs.Add(npc); // Собираем НПС
            }
        }

        public void PostCreateSprite(ISprite sprite)
        {
            var npc = sprite as INPC;

            if (npc == null)
                return;

            // При инициализации точка интереса у НПС совпадает с местоположением
            npc.IntrestingPoint = new Vector2(npc.PosX, npc.PosY);
        }

    }

}
