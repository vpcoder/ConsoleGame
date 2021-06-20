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
                        DrawPlayer(x, y);
                    } else
                    {
                        DrawObject(x, y, world.Map.Matrix[x, y]);
                    }
                }
            }
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
            if(prevPosX == world.Player.PosX && prevPosY == world.Player.PosY)
            {
                EndDraw();
                return;
            }
            System.Console.SetCursorPosition(prevPosX, prevPosY);
            DrawObject(prevPosX, prevPosY, world.Map.Matrix[prevPosX, prevPosY]);
            System.Console.SetCursorPosition(world.Player.PosX, world.Player.PosY);
            DrawPlayer(world.Player.PosX, world.Player.PosY);
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
        private void DrawPlayer(int x, int y)
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
        private void DrawObject(int x, int y, SpriteChar obj)
        {
            if(obj == null)
            {
                System.Console.Write(" ");
                return;
            }
            System.Console.ForegroundColor = obj.Color;
            System.Console.Write(obj.Symbol);
        }

    }

}
