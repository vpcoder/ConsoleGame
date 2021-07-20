using System;

namespace Engine.Data
{

    public struct Vector2
    {

        public static Vector2 Empty = new Vector2(int.MinValue, int.MinValue);
        public static Vector2 Zero = new Vector2(0, 0);
        public static Vector2 One = new Vector2(1, 1);

        public int X;

        public int Y;

        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Direction LookTo(Vector2 point)
        {
            return LookTo(this, point);
        }

        public static Direction LookTo(Vector2 start, Vector2 point)
        {
            if (start.X > point.X)
                return Direction.Left;
            if (start.X < point.X)
                return Direction.Right;
            if (start.Y > point.Y)
                return Direction.Up;
            return Direction.Down;
        }

        public int Distance(Vector2 another)
        {
            return Distance(this, another);
        }

        public static int Distance(Vector2 p1, Vector2 p2)
        {
            return (int)Math.Truncate(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));
        }

        public static bool operator ==(Vector2 o1, Vector2 o2)
        {
            return (o1.X == o2.X) && (o1.Y == o2.Y);
        }
        public static bool operator !=(Vector2 o1, Vector2 o2)
        {
            return !(o1 == o2);
        }

        public static Vector2 operator +(Vector2 o1, Vector2 o2)
        {
            return new Vector2(o1.X + o2.X, o1.Y + o2.Y);
        }
        public static Vector2 operator -(Vector2 o1, Vector2 o2)
        {
            return new Vector2(o1.X - o2.X, o1.Y - o2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if ((object)this == obj)
                return true;
            if (!(obj is Vector2))
                return false;

            Vector2 other = (Vector2)obj;
            return other == this;
        }

        public override int GetHashCode()
        {
            return ($"{X}.{Y}").GetHashCode();
        }

    }

}
