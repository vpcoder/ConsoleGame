
namespace Engine.Data
{

    /// <summary>
    /// Интерфейс спрайта
    /// </summary>
    public interface ISprite
    {

        /// <summary>
        /// Символ, которым изображён объект в мире
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// Положение объекта в мире по X
        /// </summary>
        int PosX { get; set; }

        /// <summary>
        /// Положение объекта в мире по Y
        /// </summary>
        int PosY { get; set; }

    }

    public static class ISpriteAdditional
    {
        public static Vector2 ToPos(this ISprite sprite)
        {
            return new Vector2(sprite.PosX, sprite.PosY);
        }

        public static void Move(this ISprite sprite, int x, int y)
        {
            sprite.PosX = x;
            sprite.PosY = y;
        }

        public static void Move(this ISprite sprite, Vector2 pos)
        {
            Move(sprite, pos.X, pos.Y);
        }
    }

}
