using Engine;
using Engine.Data;
using Engine.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine
{
    public partial class GraphicConsole : UserControl, IConsole
    {
        private const int CELL_COUNT_X = 60;
        private const int CELL_COUNT_Y = 60;

        private Image bufferedImage;
        private Graphics graphics;

        private const int TILE_SIZE_X = 32;
        private const int TILE_SIZE_Y = 32;

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

        public GraphicConsole()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Resize += (o, e) =>
            {
                var fontSize = CellSizeY;
                var maxW = 1280;
                var maxH = 1024;
                bufferedImage = new Bitmap(Width > maxW ? maxW : Width, Height > maxH ? maxH : Height);
                if(graphics != null)
                    graphics.Dispose();
                graphics = Graphics.FromImage(bufferedImage);
                Font = new Font("arial", fontSize <= 0 ? 1 : fontSize);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(bufferedImage, 0, 0, Width, Height);
            graphics.Clear(Color.Black);
        }

        private void GraphicConsole_Load(object sender, EventArgs e)
        {

        }

        private SolidBrush foreColorBrush = new SolidBrush(Color.Black);
        private SolidBrush backColorBrush = new SolidBrush(Color.Black);

        public void Draw(Sprite sprite, int x, int y)
        {
            if(sprite == null)
            {
                return;
            }

            var posX = x * CellSizeX;
            var posY = y * CellSizeY;

            var image = ImageFactory.Instance.Get(sprite.ID);

            if(image == null)
                return;

            graphics.DrawImage(image, posX, posY, CellSizeX, CellSizeY);
        }

        private readonly static TextFormatFlags flags = TextFormatFlags.NoPadding;
        private readonly static Size emptySize = new Size(int.MaxValue, int.MaxValue);

        public void Draw(string text, Color foreColor, Color backgroundColor, int x, int y)
        {
            var posX = x * CellSizeX;
            var posY = y * CellSizeY;
            foreColorBrush.Color = foreColor;
            if (backgroundColor != Color.Empty)
            {
                var size = TextRenderer.MeasureText(graphics, text, Font, emptySize, flags);
                backColorBrush.Color = backgroundColor;
                graphics.FillRectangle(backColorBrush, posX, posY, size.Width, size.Height);
            }
            graphics.DrawString(text, Font, foreColorBrush, posX, posY);
        }

        public void Draw(string text, Color foreColor, int x, int y)
        {
            Draw(text, foreColor, Color.Empty, x, y);
        }

    }

}
