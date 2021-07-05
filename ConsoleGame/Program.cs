using Engine.AStarSharp;
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
            IConsole console = new SystemConsole();

            var mapService = new MapService();
            var map = mapService.Load("maps/map.dat");
            var world = new World();

            world.Map = map;
            world.Player = new Player();
            world.Player.PosX = map.PlayerStartPosX;
            world.Player.PosY = map.PlayerStartPosY;
            world.Player.Inventory.Items[0] = new IronSword(); // Добавляем предметы в инвентарь
            world.Player.Inventory.Items[1] = new HealtPotion();
            world.Player.Inventory.Items[1].StackSize = 10;
            world.Player.Inventory.Items[2] = new IronArmor();
            world.Player.Inventory.Items[3] = new ClothArmor();
            world.Player.Inventory.Items[4] = new BronzeArmor();
            world.Player.Inventory.Items[5] = new PowerPotion();
            world.Player.Inventory.Items[5].StackSize = 8;
            world.Player.Inventory.Items[6] = new Apple();
            world.Player.Inventory.Items[6].StackSize = 5;
            world.Player.Inventory.Items[7] = new PowerFruit();
            world.Player.Inventory.Items[7].StackSize = 7;
            world.Player.Inventory.Items[9] = new Katana();

            var drawService = new DrawService(world, console);
            var controllService = new ControllService(world);

            AStar service = new AStar(map);

            drawService.Draw();
            for (; ; )
            {

                var key = console.ReadKey();
                var playerPosX = world.Player.PosX;
                var playerPosY = world.Player.PosY;
                controllService.Controll(key);
                drawService.Redraw(playerPosX, playerPosY);


                drawService.Draw();
                service.UpdatePathMatrix(map);
                var path = service.FindPath(new Vector2(world.Player.PosX, world.Player.PosY), new Vector2(34, 11));
                drawService.DrawPath(path);
            }

        }

    }

}
