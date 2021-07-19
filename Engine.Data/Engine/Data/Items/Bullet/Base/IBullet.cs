
namespace Engine.Data
{

    /// <summary>
    /// Интерфейс снаряда
    /// </summary>
    public interface IBullet : ISprite
    {

        /// <summary>
        /// Кто выпустил снаряд
        /// </summary>
        ICharacter Source { get; set; }

        /// <summary>
        /// Урон снаряда
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Направление движения снаряда
        /// </summary>
        Direction Direction { get; set; }

        /// <summary>
        /// Пройденный снарядом путь
        /// </summary>
        int MovePath { get; set; }

        /// <summary>
        /// Максимальная дальность снаряда
        /// </summary>
        int MoveMaxPath { get; set; }

    }

}
