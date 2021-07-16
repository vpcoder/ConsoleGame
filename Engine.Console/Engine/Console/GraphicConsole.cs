using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Console
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

        public int SizeX
        {
            get
            {
                return settings.ConsoleResolutionX;
            }
        }

        public int SizeY
        {
            get
            {
                return settings.ConsoleResolutionY;
            }
        }

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
            try
            {
                TILE_SIZE_X = settings.TileSizeX;
                TILE_SIZE_Y = settings.TileSizeY;
                CELL_COUNT_X = settings.ConsoleResolutionX;
                CELL_COUNT_Y = settings.ConsoleResolutionY;
            }
            catch { }

            InitializeComponent();
            DoubleBuffered = true;

            Resize += (o, e) =>
            {
                Width = Math.Max(Width, 10);
                Height = Math.Max(Height, 10);
                try
                {
                    var fontSize = CellSizeY * 0.5f;
                    bufferedImage = new Bitmap(CurrentWidth, CurrentHeight);
                    if (graphics != null)
                        graphics.Dispose();
                    graphics = Graphics.FromImage(bufferedImage);
                    graphics.Clear(BackColor);
                    Font = new Font("arial", fontSize <= 0 ? 1 : fontSize);
                }
                catch { }
            };
        }

        /// <summary>
        /// Рассчитывает и получает положение на матрице из положения в пикселях
        /// </summary>
        /// <param name="x">Положение в пикселях по X</param>
        /// <param name="y">Положение в пикселях по Y</param>
        /// <returns>Рассчитанную точку в матрице</returns>
        public Point GetPosition(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) // Точка за пределами карты
                return Point.Empty;
            var posX = x / CellSizeX;
            var posY = y / CellSizeY;
            return new Point(posX, posY);
        }

        public Point GetPosition(MouseEventArgs e)
        {
            if (e == null)
                return Point.Empty;
            return GetPosition(e.X, e.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(bufferedImage == null)
            {
                e.Graphics.Clear(BackColor);
                return;
            }

            e.Graphics.DrawImage(bufferedImage, 0, 0, Width, Height);
            graphics.Clear(BackColor);
        }

        private SolidBrush foreColorBrush = new SolidBrush(Color.Black);
        private SolidBrush backColorBrush = new SolidBrush(Color.Black);

        public void Draw(Image sprite, int x, int y)
        {
            Draw(sprite, Color.Empty, x, y);
        }
        
        public void Draw(Image sprite, Color backgroundColor, int x, int y)
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

            graphics.DrawImage(sprite, posX, posY, CellSizeX, CellSizeY);
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
