using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Engine.Data
{

    /// <summary>
    /// Базовый класс игрока
    /// </summary>
    public class Player : Sprite
    {
        
        public Player()
        {
            this.Color = Color.White;
            this.ID = "player/character";
        }

        /// <summary>
        /// Здоровье персонажа
        /// </summary>
        public int HP { get; set; } = 60;

        /// <summary>
        /// Максимальное здоровье персонажа
        /// </summary>

        public int MaxHP { get; set; } = 100;

        /// <summary>
        /// Оружие
        /// </summary>
        public Weapon Weapon { get; set; } = null;

        /// <summary>
        /// Баффы
        /// </summary>
        public HashSet<Buff> CurrentBuffs = new HashSet<Buff>();

        public void AddBuff(Buff buff)
        {
            CurrentBuffs.Add(buff);
            return;
        }

        // РЕАЛИЗОВАТЬ 
        
        /// <summary>
        /// Текущий урон героя
        /// </summary>
        public int Damage
        {
            get
            {
                int sumAdditionalDamage = CurrentBuffs.Count == 0 ? 0 : CurrentBuffs.Select(buff => buff.AdditionalDamage).Sum();

                if (Weapon == null)
                    return sumAdditionalDamage;

                return Weapon.Damage + sumAdditionalDamage; // если нет оружия, то нет урона. Думаю нужно добавить оружие "кулаки". когда в слоте weapon - null, будут находится кулаки, которые слабы по урону. Или же добавить на старте меч.
            }
        }

        /// <summary>
        /// Текущая защита героя
        /// </summary>
        public int Defence
        {
            get
            {
                int sumAdditionalDefence = CurrentBuffs.Count == 0 ? 0 : CurrentBuffs.Select(buff => buff.AdditionalDefence).Sum();

                if (Armor == null)
                    return sumAdditionalDefence;

                return Armor.Defence + sumAdditionalDefence;
            }
        }

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
