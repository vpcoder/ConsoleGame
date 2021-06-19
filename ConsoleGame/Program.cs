using Engine.Data;
using Engine.Services;

namespace Engine
{

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

            var drawService = new DrawService();
            var controllService = new ControllService(world);

            for (; ; )
            {
                var key = System.Console.ReadKey();
                controllService.Controll(key);
                drawService.Draw(world);
            }

        }

    }

}
