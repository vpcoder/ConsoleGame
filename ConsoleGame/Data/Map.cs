
namespace Engine.Data
{

    public class Map
    {

        public SpriteChar[,] matrix;

        public Map(int w, int h)
        {
            matrix = new SpriteChar[w, h];
        }

    }

}
