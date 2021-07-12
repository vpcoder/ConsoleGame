using Engine.AStarSharp;
using Engine.Data;
using Engine.Services;
using System;
using System.Windows.Forms;

namespace Engine
{

    public partial class Game : Form
    {
        private static int globalFps = 0;

        private Map        map;
        private World      world;

        private DrawService drawService;
        private ControllService controllService;

        public Game()
        {
            InitializeComponent();

            DoubleBuffered = true;
            Width = 1024;
            Height = 720;

            var timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1;
            timer.Tick += Runtime;
            console.KeyDown += OnKeyDown;
            KeyDown += OnKeyDown;

            var fpsTimer = new Timer();
            fpsTimer.Enabled = true;
            fpsTimer.Interval = 1000;
            fpsTimer.Tick += (o, e) =>
            {
                Text = $"game; fps: {globalFps}";
                globalFps = 0;
            };

            Shown += GameLoad;

            map = MapService.Instance.Load("maps/map.dat");
            world = new World();

            world.Map = map;
            world.View = new Data.View();
            world.Player = new Data.Player();
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
            controllService.Controll(e);
            drawService.Draw();
            console.Refresh();
        }

        private void Runtime(object sender, EventArgs e)
        {
            globalFps++;
            drawService.Draw();
            console.Refresh();
        }

        private void GameLoad(object sender, EventArgs e)
        {
            console.Refresh();
        }

    }

}
