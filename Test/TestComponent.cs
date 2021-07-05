using Engine;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class TestComponent : UserControl, IConsole
    {
        private const int CELL_COUNT_X = 10;
        private const int CELL_COUNT_Y = 10;

        public int CellSizeX
        {
            get
            {
                return Width / CELL_COUNT_X;
            }
        }

        public int CellSizeY
        {
            get
            {
                return Height / CELL_COUNT_Y;
            }
        }

        // world ? ⚙ 😇
        private static readonly Pen pen = new Pen(Color.Red);
        private static readonly Brush Symbol = new SolidBrush(Color.White);
        private static readonly Random rnd = new Random();

        public TestComponent()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);

            for (int x = 0; x < CELL_COUNT_X; x++)
            {
                var posX = x * CellSizeX;
                g.DrawLine(pen, posX, 0, posX, Height);
            }
            for (int y = 0; y < CELL_COUNT_Y; y++)
            {
                var posY = y * CellSizeY;
                g.DrawLine(pen, 0, posY, Width, posY);
            }

            for (int y = 0; y < CELL_COUNT_Y; y++) { 
                for(int x = 0; x < CELL_COUNT_X; x++)
                {
                    var posX = x * CellSizeX;
                    var posY = y * CellSizeY;
                    var data = ((char)rnd.Next(255)).ToString();
                    g.DrawString(data, Font, Symbol, posX, posY);
                }
            }
        }

        private void TestComponent_Load(object sender, EventArgs e)
        {

        }

        public void Draw(string text, Color foreColor, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Draw(string text, Color foreColor, Color backgroundColor, int x, int y)
        {
            throw new NotImplementedException();
        }

        public int ReadKey()
        {
            throw new NotImplementedException();
        }
    }
}
