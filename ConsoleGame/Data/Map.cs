
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
        /// Матрица карты
        /// </summary>
        public SpriteChar[,] Matrix;

        /// <summary>
        /// Инициализация карты (конструкторв)
        /// </summary>
        /// <param name="w">Размер карты по X (ширина)</param>
        /// <param name="h">Размер карты по Y (высота)</param>
        public Map(int w, int h)
        {
            this.SizeX = w;
            this.SizeY = h;
            this.Matrix = new SpriteChar[w, h];
        }

    }

}
