
namespace Engine.Data
{

    /// <summary>
    /// Объект карты
    /// </summary>
    public class Map
    {

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
        public Sprite[,] Matrix0;

        /// <summary>
        /// Матрица карты - то что лежит "сверху"
        /// </summary>
        public Sprite[,] Matrix1;

        /// <summary>
        /// Инициализация карты (конструкторв)
        /// </summary>
        /// <param name="w">Размер карты по X (ширина)</param>
        /// <param name="h">Размер карты по Y (высота)</param>
        public Map(int w, int h)
        {
            this.SizeX = w;
            this.SizeY = h;
            this.Matrix0 = new Sprite[w, h];
            this.Matrix1 = new Sprite[w, h];
        }

        public Sprite Background(int x, int y)
        {
            if (!isIntersection(x, y))
                return null;
            return Matrix0[x, y];
        }

        public Sprite Frontground(int x, int y)
        {
            if (!isIntersection(x, y))
                return null;
            return Matrix1[x, y];
        }
        
        private bool isIntersection(int x, int y)
        {
            return !(x < 0 || x >= SizeX || y < 0 || y >= SizeY);
        }

    }

}
