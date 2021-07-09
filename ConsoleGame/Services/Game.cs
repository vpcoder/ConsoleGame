using Engine.AStarSharp;
using Engine.Data;
using Engine.Services;
using System;
using System.Windows.Forms;

namespace Engine
{

    public partial class Game : Form
    {

        private MapService mapService;
        private Map        map;
        private World      world;

        private DrawService drawService;
        private ControllService controllService;

        public Game()
        {
            InitializeComponent();

            DoubleBuffered = true;

            var timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 500;
            timer.Tick += Runtime;
            console.KeyDown += OnKeyDown;
            Shown += GameLoad;

            mapService = new MapService();
            map = mapService.Load("maps/map.dat");
            world = new World();

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

            drawService = new DrawService(world, console);
            controllService = new ControllService(world);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var playerPosX = world.Player.PosX;
            var playerPosY = world.Player.PosY;
            controllService.Controll((int)e.KeyCode);
            drawService.Redraw(playerPosX, playerPosY);
            console.Refresh();
        }

        private void Runtime(object sender, EventArgs e)
        {
            drawService.Draw();
            console.Refresh();
        }

        private void GameLoad(object sender, EventArgs e)
        {
            console.Refresh();
        }

    }

}
