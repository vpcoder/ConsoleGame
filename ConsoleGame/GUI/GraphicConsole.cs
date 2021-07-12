using Engine.Data;
using Engine.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine
{

    public partial class GraphicConsole : UserControl, IConsole
    {
        private static Properties.Settings settings = Properties.Settings.Default;

        private readonly int CELL_COUNT_X;
        private readonly int CELL_COUNT_Y;

        private readonly int TILE_SIZE_X;
        private readonly int TILE_SIZE_Y;

        private Image bufferedImage;
        private Graphics graphics;

        public int ViewWidth
        {
            get
            {
                return CELL_COUNT_X;
            }
        }

        public int ViewHeight
        {
            get
            {
                return CELL_COUNT_Y;
            }
        }

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

        private int CurrentWidth
        {
            get
            {
                if(Width <= 0 || Width > settings.MaxWidth)
                {
                    return settings.DefaultResolutionX;
                }
                return Width;
            }
        }

        private int CurrentHeight
        {
            get
            {
                if (Height <= 0 || Height > settings.MaxHeight)
                {
                    return settings.DefaultResolutionY;
                }
                return Height;
            }
        }

        public GraphicConsole()
        {
            TILE_SIZE_X = settings.TileSizeX;
            TILE_SIZE_Y = settings.TileSizeY;
            CELL_COUNT_X = settings.ConsoleResolutionX;
            CELL_COUNT_Y = settings.ConsoleResolutionY;

            InitializeComponent();
            DoubleBuffered = true;

            Resize += (o, e) =>
            {
                var fontSize = CellSizeY;
                bufferedImage = new Bitmap(CurrentWidth, CurrentHeight);
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
            Draw(sprite, Color.Empty, x, y);
        }

        public void Draw(Sprite sprite, Color backgroundColor, int x, int y)
        {
            var posX = x * CellSizeX;
            var posY = y * CellSizeY;

            if (backgroundColor != Color.Empty)
            {
                DrawRect(backgroundColor, posX, posY, CellSizeX, CellSizeY);
            }

            if (sprite == null)
            {
                return;
            }

            var image = ImageFactory.Instance.Get(sprite.ID);

            if (image == null)
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
                DrawRect(backgroundColor, posX, posY, size.Width, size.Height);
            }
            graphics.DrawString(text, Font, foreColorBrush, posX, posY);
        }

        private void DrawRect(Color backgroundColor, int x, int y, int w, int h)
        {
            backColorBrush.Color = backgroundColor;
            graphics.FillRectangle(backColorBrush, x, y, w, h);
        }

        public void Draw(string text, Color foreColor, int x, int y)
        {
            Draw(text, foreColor, Color.Empty, x, y);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

    }

}
