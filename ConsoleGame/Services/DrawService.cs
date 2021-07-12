using Engine.AStarSharp;
using Engine.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Сервис отрисовки нашего мира, и его частей
    /// </summary>
    public class DrawService
    {

        private IConsole console;
        private World world;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса отрисовки
        /// </summary>
        public DrawService(World world, IConsole console)
        {
            this.world = world;
            this.console = console;
        }

        /// <summary>
        /// Отрисовывает мир - медленный и неоптимальный метод, не подходит для постоянной перерисовки,
        /// но подходит для первичного отображения карты
        /// </summary>
        /// <param name="world">Мир, который нужно отрисовать</param>
        public void Draw()
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

                        DrawObject(sprite, x, y, Color.Empty); // Рисуем объект в области видимости на указанном слое

                        if (map.CenterLayout == layout && world.Player.PosX == x && world.Player.PosY == y)
                        {
                            DrawObject(world.Player, x, y, Color.Empty);
                        }
                    }
                }
            }
            DrawInventory();
            DrawPlayerCharacteristic();

            console.Draw("input:", Color.White, 0, world.Map.SizeY + 1);
        }

        public void DrawPath(List<Node> path)
        {
            if (path == null)
            {
                return;
            }
            foreach (var node in path)
            {
                console.Draw("▒", Color.Green, node.Position.X, node.Position.Y);
            }
        }

        /// <summary>
        /// Рисует объект в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение объекта по X</param>
        /// <param name="y">Располоэение объекта по Y</param>
        /// <param name="obj">Рисуемый объект</param>
        private void DrawObject(Sprite obj, int posX, int posY, Color backgroundClolor)
        {
            console.Draw(obj, backgroundClolor, posX, posY);
        }

        /// <summary>
        /// Рисует инвентарь в игре
        /// </summary>
        private void DrawInventory()
        {
            var inventory = world.Player.Inventory;
            var index = -1;
            foreach (Item item in inventory.Items)
            {
                index++;
                if (inventory.SelectedIndex == index)
                {
                    console.Draw(GetNormalizedText(item?.Title), Color.White, world.Map.SizeX + 2, 6);
                    console.Draw(GetNormalizedText(GenerateItemDescription(item)), Color.White, world.Map.SizeX + 2, 7);
                    DrawObject(item, world.Map.SizeX + 2 + index % 5, 1 + index / 5, Color.Green);
                }
                else
                {
                    DrawObject(item, world.Map.SizeX + 2 + index % 5, 1 + index / 5, Color.Empty);

                }
            }
        }

        private void DrawPlayerCharacteristic()
        {
            /*
            var player = world.Player;

            var barLength = world.Player.HP / (world.Player.MaxHP / 10);
            var emptyLength = 10 - barLength;
            var progress = (string.Empty.PadRight(barLength, '█')).PadRight(10, '▒') + $" {world.Player.HP}/{world.Player.MaxHP}";

            console.Draw(progress, Color.DarkRed, world.Map.SizeX + 2, 9);

            var info = $"АТК: {world.Player.Damage} ЗАЩ: {world.Player.Defence}   ";
            console.Draw(info, Color.White, world.Map.SizeX + 2, 11);
            */
        }

        private string GenerateItemDescription(Item item)
        {
            if (item == null)
                return null;
            StringBuilder builder = new StringBuilder();
            builder.Append(item.Description);

            if (item is Armor)
            {
                var armor = (Armor)item;
                builder.Append(" +" + armor.Defence + "ед. защиты");
            }
            if (item is Weapon)
            {
                var weapon = (Weapon)item;
                builder.Append(" +" + weapon.Damage + "ед. урона");
            }
            if (item is UsedItem)
            {
                var usedItem = (UsedItem)item;
                builder.Append(" <используется>");
            }

            if (item.MaxStackSize != 1)
                builder.Append(" " + item.StackSize + "/" + item.MaxStackSize + " шт.");

            return builder.ToString();
        }

        private string GetNormalizedText(string text)
        {
            if (text == null)
            {
                return string.Empty.PadRight(70, ' ');
            }
            return text.PadRight(70, ' ');
        }

    }

}
