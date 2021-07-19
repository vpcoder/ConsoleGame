
namespace Engine.Data
{

    /// <summary>
    /// Оружие
    /// </summary>
    public interface IWeapon : IItem
    {
        
        /// <summary>
        /// Урон от оружия
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Интервал использования оружия
        /// </summary>
        double UseInterval { get; set; }

    }

}
