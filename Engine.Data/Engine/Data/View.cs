using System;


namespace Engine.Data
{

    public class View
    {

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public Vector2 GetPointInWorld(Vector2 point)
        {
            return GetPointInWorld(point.X, point.Y);
        }

        public Vector2 GetPointInWorld(int x, int y)
        {
            return new Vector2(x + PosX, y + PosY);
        }

        public Vector2 GetPointInView(Vector2 point)
        {
            return GetPointInView(point.X, point.Y);
        }

        public Vector2 GetPointInView(int x, int y)
        {
            return new Vector2(x - PosX, y - PosY);
        }

        public bool IsPointInView(Vector2 point)
        {
            return IsPointInView(point.X, point.Y);
        }

        public bool IsPointInView(int x, int y)
        {
            return x >= PosX && x <= PosX + SizeX
                && y >= PosY && y <= PosY + SizeY;
        }

    }

}
