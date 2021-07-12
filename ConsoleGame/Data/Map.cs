
namespace Engine.Data
{

    /// <summary>
    /// Объект карты
    /// </summary>
    public class Map
    {

        private const int LAYOUT_COUNT = 7;

        public int LayoutCount { get; } = LAYOUT_COUNT;

        public int CenterLayout { get; } = (LAYOUT_COUNT / 2) + 1;

        /// <summary>
        /// Стартовая позиция персонажа на карте по X
        /// </summary>
        public int PlayerStartPosX { get; set; }
        /// <summary>
        /// Стартовая позиция персонажа на карте по Y
        /// </summary>
        public int PlayerStartPosY { get; set; }

        /// <summary>
        /// Размер карты по X
        /// </summary>
        public int SizeX { get; }
        /// <summary>
        /// Размер карты по Y
        /// </summary>
        public int SizeY { get; }

        /// <summary>
        /// Матрица карты - то что лежит "снизу"
        /// </summary>
        private Sprite[][,] Matrix;

        /// <summary>
        /// Инициализация карты (конструкторв)
        /// </summary>
        /// <param name="w">Размер карты по X (ширина)</param>
        /// <param name="h">Размер карты по Y (высота)</param>
        public Map(int w, int h)
        {
            this.SizeX = w;
            this.SizeY = h;
            this.Matrix = new Sprite[LayoutCount][,];
            for(int layout = 0; layout < LayoutCount; layout++)
                this.Matrix[layout] = new Sprite[w, h];
        }

        public Sprite Get(int layout, int x, int y)
        {
            if (!isIntersection(x, y))
                return null;
            return Matrix[layout][x, y];
        }

        public void Set(Sprite sprite, int layout, int x, int y)
        {
            this.Matrix[layout][x, y] = sprite;
        }

        public bool IsWalkable(int x, int y)
        {
            if(!isIntersection(x,y))
                return false;
            for(int layout = CenterLayout; layout<=0; layout--)
            {
                var sprite = Matrix[layout][x, y];
                if(sprite == null)
                {
                    continue;
                }
                var obj = sprite as Object;
                if(obj == null)
                {
                    continue;
                }
                if(obj.Walkable)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private bool isIntersection(int x, int y)
        {
            return !(x < 0 || x >= SizeX || y < 0 || y >= SizeY);
        }

    }

}
