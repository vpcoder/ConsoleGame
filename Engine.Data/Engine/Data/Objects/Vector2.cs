
namespace Engine.Data
{

    public struct Vector2
    {
        public static Vector2 Zero = new Vector2(int.MinValue, int.MinValue);

        public int X;

        public int Y;

        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }

}
