using Engine.Data;
using Engine.Services;

namespace Engine
{

    /// <summary>
    /// Точка входа программы
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            var mapService = new MapService();
            var map = mapService.Load("maps/map.dat");
            var world = new World();

            world.Map = map;
            world.Player = new Player();
            world.Player.PosX = map.PlayerStartPosX;
            world.Player.PosY = map.PlayerStartPosY;
            world.Player.Inventory.Items[0] = new IronSword(); // Добавляем предметы в инвентарь
            world.Player.Inventory.Items[1] = new HealtPotion();

            var drawService = new DrawService(world);
            var controllService = new ControllService(world);

            drawService.Draw();
            for (; ; )
            {
                var key = System.Console.ReadKey();
                var playerPosX = world.Player.PosX;
                var playerPosY = world.Player.PosY;
                controllService.Controll(key);
                drawService.Redraw(playerPosX, playerPosY);
            }

        }

    }

}
