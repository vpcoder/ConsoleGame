using Engine.AStarSharp;
using Engine.Data;
using System.Collections.Generic;
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
            for(var y = 0; y < world.Map.SizeY; y++)
            {
                for (var x = 0; x < world.Map.SizeX; x++)
                {
                    System.Console.SetCursorPosition(x, y);
                    if(world.Player.PosX == x && world.Player.PosY == y)
                    {
                        DrawPlayer();
                    } else
                    {
                        DrawObject(GetVisibleObject(x, y));
                    }
                }
            }
            DrawInventory();

            System.Console.SetCursorPosition(0, world.Map.SizeY+1);
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.Write("input:");
            EndDraw();
        }

        private SpriteChar GetVisibleObject(int x, int y)
        {
            var map = world.Map;
            return map.Frontground(x, y) ?? map.Background(x, y); // Сначала смотрим на то что на переднем плане, а потом на то что на заднем плане
        }

        /// <summary>
        /// Метод перерисовки последнего местоположения персонажа
        /// </summary>
        public void Redraw(int prevPosX, int prevPosY)
        {
            System.Console.SetCursorPosition(prevPosX, prevPosY);
            DrawObject(GetVisibleObject(prevPosX, prevPosY));
            System.Console.SetCursorPosition(world.Player.PosX, world.Player.PosY);
            DrawPlayer();
            DrawInventory();
            EndDraw();
        }

        public void DrawPath(List<Node> path)
        {
            if (path == null)
            {
                EndDraw();
                return;
            }
            foreach(var node in path)
            {
                System.Console.SetCursorPosition(node.Position.X, node.Position.Y);
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                System.Console.Write("▒");
            }
            EndDraw();
        }

        private void EndDraw()
        {
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.SetCursorPosition(7, world.Map.SizeY + 1);
        }

        /// <summary>
        /// Рисует персонажа в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение персонажа по X</param>
        /// <param name="y">Располоэение персонажа по Y</param>
        private void DrawPlayer()
        {
            System.Console.ForegroundColor = world.Player.Color;
            System.Console.Write(world.Player.Symbol);
        }

        /// <summary>
        /// Рисует объект в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение объекта по X</param>
        /// <param name="y">Располоэение объекта по Y</param>
        /// <param name="obj">Рисуемый объект</param>
        private void DrawObject(SpriteChar obj)
        {
            if(obj == null)
            {
                System.Console.Write(" ");
                return;
            }
            System.Console.ForegroundColor = obj.Color;
            System.Console.Write(obj.Symbol);
        }

        /// <summary>
        /// Рисует инвентарь в игре
        /// </summary>
        private void DrawInventory()
        {
            var inventory = world.Player.Inventory;
            var index = -1;
            foreach(Item item in inventory.Items)
            {
                index++;
                if (inventory.SelectedIndex == index)
                {
                    System.Console.ForegroundColor = System.ConsoleColor.White;
                    System.Console.SetCursorPosition(world.Map.SizeX + 2, 6);
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                    System.Console.Write(GetNormalizedText(item?.Title));
                    System.Console.SetCursorPosition(world.Map.SizeX + 2, 7);
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                    System.Console.Write(GetNormalizedText(GenerateItemDescription(item)));

                    System.Console.BackgroundColor = System.ConsoleColor.DarkGreen;
                }
                else
                {
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                }
                System.Console.SetCursorPosition(world.Map.SizeX + 2 + index % 5, 1 + index / 5);
                DrawObject(item);
            }
        }

        private string GenerateItemDescription(Item item)
        {
            if (item == null)
                return null;
            StringBuilder builder = new StringBuilder();
            builder.Append(item.Description);

            if(item is Armor)
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
            if(text == null)
            {
                return string.Empty.PadRight(50, ' ');
            }
            return text.PadRight(50, ' ');
        }

    }

}
