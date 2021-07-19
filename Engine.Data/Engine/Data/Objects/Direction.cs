
namespace Engine.Data
{

    /// <summary>
    /// Енум определяющий вектор движения (направление)
    /// </summary>
    public enum Direction : int
    {

        /// <summary>
        /// Влево
        /// </summary>
        Left,

        /// <summary>
        /// Вверх
        /// </summary>
        Up,

        /// <summary>
        /// Вправо
        /// </summary>
        Right,

        /// <summary>
        /// Вниз
        /// </summary>
        Down,

    };

    public static class DirectionExtension
    {

        public static Vector2 ToVector(this Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:   return new Vector2(-1, 0);
                case Direction.Right:  return new Vector2(+1, 0);
                case Direction.Up:    return new Vector2(0, -1);
                case Direction.Down: return new Vector2(0, +1);
            }
            return Vector2.Zero;
        }

    }

}
