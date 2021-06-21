using Engine.Data;
using System.Drawing;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Сервис отрисовки нашего мира, и его частей
    /// </summary>
    public class DrawService
    {
        public Point LastPlayerPosition { get; set; }

        public void SaveLastPositionPlayer(World world)
        {
            LastPlayerPosition = new Point(world.Player.PosX, world.Player.PosY);
        }
        
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
                        DrawPlayer(world.Player);
                    } else
                    {
                        DrawObject(world.Map.matrix[x, y]);
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
        public void Redraw(World world)
        {
            System.Console.SetCursorPosition(LastPlayerPosition.X, LastPlayerPosition.Y);
            DrawObject(world.Map.matrix[LastPlayerPosition.X, LastPlayerPosition.Y]);

            System.Console.SetCursorPosition(world.Player.PosX, world.Player.PosY);
            DrawPlayer(world.Player);

            System.Console.SetCursorPosition(0, 9);
            System.Console.Write("\b \b");
            



        }

        private void DrawPlayer(Player player)
        {
            System.Console.ForegroundColor = player.Color;
            System.Console.Write(player.Symbol);
        }

        private void DrawObject( SpriteChar obj)
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
