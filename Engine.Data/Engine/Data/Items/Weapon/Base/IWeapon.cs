
namespace Engine.Data
{

    public interface IWeapon : IItem
    {
        
        /// <summary>
        /// Урон от оружия
        /// </summary>
        int Damage { get; set; }

    }

}
