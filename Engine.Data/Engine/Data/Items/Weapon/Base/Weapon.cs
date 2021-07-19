
namespace Engine.Data
{

    /// <summary>
    /// Базовый класс оружия
    /// </summary>
    public abstract class Weapon : Item, IWeapon
    {

        /// <summary>
        /// Урон от оружия
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Интервал использования оружия
        /// </summary>
        public double UseInterval { get; set; }

    }

}
