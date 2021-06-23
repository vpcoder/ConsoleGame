using Engine.Data;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Сервис отрисовки нашего мира, и его частей
    /// </summary>
    public class DrawService
    {

        private World world;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса отрисовки
        /// </summary>
        public DrawService(World world)
        {
            this.world = world;
            System.Console.OutputEncoding = Encoding.UTF8;
            System.Console.InputEncoding  = Encoding.UTF8;
        }

        /// <summary>
        /// Отрисовывает мир - медленный и неоптимальный метод, не подходит для постоянной перерисовки,
        /// но подходит для первичного отображения карты
        /// </summary>
        /// <param name="world">Мир, который нужно отрисовать</param>
        public void Draw()
        {
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
                        DrawObject(world.Map.Matrix[x, y]);
                    }
                }
            }
            DrawInventory();

            System.Console.SetCursorPosition(0, world.Map.SizeY+1);
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.Write("input:");
            EndDraw();
        }

        /// <summary>
        /// Метод перерисовки последнего местоположения персонажа
        /// </summary>
        public void Redraw(int prevPosX, int prevPosY)
        {
            System.Console.SetCursorPosition(prevPosX, prevPosY);
            DrawObject(world.Map.Matrix[prevPosX, prevPosY]);
            System.Console.SetCursorPosition(world.Player.PosX, world.Player.PosY);
            DrawPlayer();
            DrawInventory();
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
                    System.Console.SetCursorPosition(world.Map.SizeX + 2, 4);
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                    System.Console.Write(GetNormalizedTetxt(item?.Title));
                    System.Console.SetCursorPosition(world.Map.SizeX + 2, 5);
                    System.Console.BackgroundColor = System.ConsoleColor.Black;
                    System.Console.Write(GetNormalizedTetxt(item?.Description));

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

        private string GetNormalizedTetxt(string text)
        {
            if(text == null)
            {
                return string.Empty.PadRight(30, ' ');
            }
            return text.PadRight(30, ' ');
        }

    }

}
