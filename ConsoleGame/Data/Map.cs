
namespace Engine.Data
{

    public class Map
    {

        public int PlayerStartPosX { get; set; }
        public int PlayerStartPosY { get; set; }

        public int SizeX { get; }
        public int SizeY { get; }

        public SpriteChar[,] matrix;

        public Map(int w, int h)
        {
            SizeX = w;
            SizeY = h;
            matrix = new SpriteChar[w, h];
        }

    }

}
