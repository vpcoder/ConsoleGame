
namespace Engine.Data
{

    public abstract class Character : Sprite, ICharacter
    {

        /// <summary>
        /// Направление персонажа
        /// </summary>
        public Direction Direction { get; set; } = Direction.Down;

        /// <summary>
        /// Параметры существа
        /// </summary>
        public ICharacteristics Characteristics { get; set; } = new Characteristics();

        /// <summary>
        /// Оружие
        /// </summary>
        public IWeapon Weapon { get; set; } = null;

        /// <summary>
        /// Броня персонажа
        /// </summary>
        public IArmor Armor { get; set; } = null;

        /// <summary>
        /// Инвентарь
        /// </summary>
        public IInventory Inventory { get; set; } = new Inventory();

    }

}
