using Engine.Data;
using Engine.Data.Impls;
using System.IO;

namespace Engine.Services
{

    /// <summary>
    /// Сервис работы с картами
    /// </summary>
    public class MapService
    {

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

            for(int y = 0; y < mapSizeY; y++)
            {
                for(int x = 0; x < mapSizeX; x++)
                {
                    int itemY = y + 2;
                    int itemX = x;
                    map.Matrix0[x, y] = ReadItem(x, y, mapData[itemY][itemX].ToString()); // Заполняем первый слой
                    map.Matrix1[x, y] = ReadItem(x, y, mapData[itemY + mapSizeY][itemX].ToString()); // Заполняем второй слой
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
