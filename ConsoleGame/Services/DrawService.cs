using Engine.Data;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Сервис отрисовки нашего мира, и его частей
    /// </summary>
    public class DrawService
    {

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса отрисовки
        /// </summary>
        public DrawService()
        {
            System.Console.OutputEncoding = Encoding.UTF8;
            System.Console.InputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Отрисовывает мир
        /// </summary>
        /// <param name="world">Мир, который нужно отрисовать</param>
        public void Draw(World world)
        {
            System.Console.Clear();
            for(var y = 0; y < world.Map.SizeY; y++)
            {
                for (var x = 0; x < world.Map.SizeX; x++)
                {
                    if(world.Player.PosX == x && world.Player.PosY == y)
                    {
                        DrawPlayer(x, y, world.Player);
                    } else
                    {
                        DrawObject(x, y, world.Map.matrix[x, y]);
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="world">Мир, который нужно перерисовать</param>
        public void Redraw(int prevPosX, int prevPosY, World world)
        {
            // Реализовать перерисовку старого местоположения персонажа, не перерисовывая весь мир!

        }

        private void DrawPlayer(int x, int y, Player player)
        {
            System.Console.ForegroundColor = player.Color;
            System.Console.Write(player.Symbol);
        }

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
