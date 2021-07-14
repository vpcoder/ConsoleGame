using Engine.Console;
using Engine.Data;
using Engine.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameEditor
{

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
        /// Спрашивает у пользователя как создавать новую карту
        /// </summary>
        /// <returns>Новую карту</returns>
        public Map CreateNewMap()
        {
            var dialog = new NewMapDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            var size = dialog.MapSize;
            var map = new Map(size.Width, size.Height);
            map.Name = dialog.MapName;

            return map;
        }

        public void DrawMap(World world, IConsole console)
        {
            var map = world.Map;
            for (int layout = 0; layout < map.LayoutCount; layout++) // Перебираем слои карты
            {
                for (var y = 0; y < console.ViewHeight; y++) // Перебираем объекты во фрейме
                {
                    for (var x = 0; x < console.ViewWidth; x++) // Перебираем объекты во фрейме
                    {
                        var indexX = x + world.View.PosX;
                        var indexY = y + world.View.PosY;

                        var sprite = map.Get(layout, indexX, indexY); // Получаем объект в указанной точке карты на указанном слое
                        var image = sprite == null ? null : ImageFactory.Instance.Get(sprite.ID);

                        console.Draw(image, x, y);
                    }
                }
            }
            ((Control)console).Refresh();
        }

    }

}
