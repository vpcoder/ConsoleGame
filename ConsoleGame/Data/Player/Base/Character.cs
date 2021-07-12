
namespace Engine.Data
{

    public abstract class Character : Sprite
    {

        /// <summary>
        /// Параметры существа
        /// </summary>
        public Characteristics Characteristics { get; set; } = new Characteristics();

        /// <summary>
        /// Оружие
        /// </summary>
        public Weapon Weapon { get; set; } = null;

        /// <summary>
        /// Броня персонажа
        /// </summary>
        public Armor Armor { get; set; } = null;

        /// <summary>
        /// Инвентарь
        /// </summary>
        public Inventory Inventory { get; set; } = new Inventory();

    }

}
