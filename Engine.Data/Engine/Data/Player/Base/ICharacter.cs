

namespace Engine.Data
{

    public interface ICharacter : ISprite
    {
        /// <summary>
        /// Параметры существа
        /// </summary>
        ICharacteristics Characteristics { get; set; }

        /// <summary>
        /// Оружие
        /// </summary>
        IWeapon Weapon { get; set; }

        /// <summary>
        /// Броня персонажа
        /// </summary>
        IArmor Armor { get; set; }

        /// <summary>
        /// Инвентарь
        /// </summary>
        IInventory Inventory { get; set; }
    }

}
