
namespace Engine.Data
{

    /// <summary>
    /// Енум определяющий вектор движения (направление)
    /// </summary>
    public enum Direction : int
    {

        /// <summary>
        /// Пустой вектор
        /// </summary>
        None,

        /// <summary>
        /// Влево
        /// </summary>
        Left,

        /// <summary>
        /// Вверх
        /// </summary>
        Top,

        /// <summary>
        /// Вправо
        /// </summary>
        Right,

        /// <summary>
        /// Вниз
        /// </summary>
        Bottom,

    };

    public static class DirectionExtension
    {

        public static Vector2 ToVector(this Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:   return new Vector2(-1, 0);
                case Direction.Right:  return new Vector2(+1, 0);
                case Direction.Top:    return new Vector2(0, -1);
                case Direction.Bottom: return new Vector2(0, +1);
                default:
                    return Vector2.Zero;
            }
        }

    }

}
