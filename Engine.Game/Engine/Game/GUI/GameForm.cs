using Engine.Data;
using Engine.Services;
using System;
using System.Windows.Forms;

namespace Engine
{

    public partial class GameForm : Form
    {
        private static int globalFps = 0;

        private World world;

        private DrawService     drawService;
        private ControllService controllService;
        private AIService       aiService;
        private BattleService   battleService;

        public GameForm()
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


            world = new World();
            MapService.Instance.Load("maps/map.dat", world);
            world.View.SizeX = console.SizeX;
            world.View.SizeY = console.SizeY;

            world.Player.Inventory.TryAddItem(new IronSword()); // Добавляем предметы в инвентарь
            world.Player.Inventory.TryAddItem(new HealtPotion(), 10);
            world.Player.Inventory.TryAddItem(new IronArmor());
            world.Player.Inventory.TryAddItem(new ClothArmor());
            world.Player.Inventory.TryAddItem(new BronzeArmor());
            world.Player.Inventory.TryAddItem(new PowerPotion(), 8);
            world.Player.Inventory.TryAddItem(new Apple(), 5);
            world.Player.Inventory.TryAddItem(new PowerFruit(), 7);
            world.Player.Inventory.TryAddItem(new Katana());

            drawService = new DrawService(world, console);
            controllService = new ControllService(world);
            aiService = new AIService(world);
            battleService = new BattleService(world, aiService);
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

            aiService.DoIteration();
            battleService.DoIteration();

            drawService.Draw();
            console.Refresh();
        }

        private void GameLoad(object sender, EventArgs e)
        {
            console.Refresh();
        }

    }

}
