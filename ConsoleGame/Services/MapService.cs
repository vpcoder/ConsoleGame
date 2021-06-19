using Engine.Data;
using Engine.Data.Impls;
using System.IO;

namespace Engine.Services
{

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
            string[] mapData = File.ReadAllText(mapName).Replace("\r", "").Split('\n');
            string name = mapData[0];
            string[] playerPosition = mapData[1].Split(',');

            int posX = int.Parse(playerPosition[0]);
            int posY = int.Parse(playerPosition[1]);

            int mapSizeX = mapData[mapData.Length - 1].Length;
            int mapSizeY = mapData.Length - 2;

            var map = new Map(mapSizeX, mapSizeY);

            for(int y = 0; y < mapSizeY; y++)
            {
                for(int x = 0; x < mapSizeX; x++)
                {
                    int itemY = y + 2;
                    int itemX = x;
                    map.matrix[x, y] = ReadItem(x, y, mapData[itemY][itemX].ToString());
                }
            }

            map.PlayerStartPosX = posX;
            map.PlayerStartPosY = posY;

            return map;
        }

        private SpriteChar ReadItem(int x, int y, string txtItem)
        {
            SpriteChar item;
            switch(txtItem)
            {
                case "Ψ":
                    item = new Tree();
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
