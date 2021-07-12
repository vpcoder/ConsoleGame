using Engine.Data;
using Engine.Data.Impls;
using System;
using System.IO;

namespace Engine.Services
{

    /// <summary>
    /// Сервис работы с картами
    /// </summary>
    public class MapService
    {

        private static Lazy<MapService> instance = new Lazy<MapService>(() => new MapService());

        public static MapService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// Сохраняет наш мир в файл
        /// </summary>
        /// <param name="map">Мир, который нужно сохранить</param>
        /// <param name="mapName">Имя файла, в который нужно сохранить мир</param>
        public void Save(Map map, string mapName)
        {
            
        }

        /// <summary>
        /// Загружает наш мир из файла
        /// </summary>
        /// <param name="mapName">Файл мира, который нужно загрузить</param>
        /// <returns>Прочитанный объект мира</returns>
        public Map Load(string mapName)
        {
            int LAYOUTS_COUNT = 2; // Число слоёв на карте

            string[] mapData = File.ReadAllText(mapName).Replace("\r", "").Split('\n');
            string name = mapData[0];
            string[] playerPosition = mapData[1].Split(',');

            int mapSizeX = mapData[mapData.Length - 1].Length;
            int mapSizeY = (mapData.Length - 2) / LAYOUTS_COUNT;

            var map = new Map(mapSizeX, mapSizeY);

            var layout = 0;
            for(int y = 0; y < mapSizeY; y++)
            {
                for(int x = 0; x < mapSizeX; x++)
                {
                    var itemY = y + 2;
                    var itemX = x;
                    var sprite = ReadItem(x, y, mapData[itemY][itemX].ToString()); // Заполняем слой
                    map.Set(sprite, layout, x, y);
                }
            }

            int posX = int.Parse(playerPosition[0]);
            int posY = int.Parse(playerPosition[1]);
            map.PlayerStartPosX = posX;
            map.PlayerStartPosY = posY;

            return map;
        }

        private Sprite ReadItem(int x, int y, string txtItem)
        {
            Sprite item;
            switch(txtItem)
            {
                case "Ψ":
                    item = new Cactus();
                    break;
                case "░":
                    item = new Road();
                    break;
                case "█":
                    item = new Brick();
                    break;
                case " ":
                    item = null;
                    break;
                case "=":
                    item = new Bridge();
                    break;
                case "T":
                    item = new Tree();
                    break;
                case "d":
                    item = new Grass();
                    break;
                case "w":
                    item = new Water();
                    break;
                case "W":
                    item = new DarkWater();
                    break;
                case "s":
                    item = new Sand();
                    break;
                default:
                    item = null;
                    break;
            }

            if(item != null)
            {
                item.PosX = x;
                item.PosY = y;
            }

            return item;
        }

    }

}
