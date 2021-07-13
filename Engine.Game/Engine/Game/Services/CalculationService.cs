using Engine.Data;
using System;
using System.Linq;

namespace Engine.Services
{

    /// <summary>
    /// Сервис расчётов
    /// </summary>
    public class CalculationService
    {

        private static Lazy<CalculationService> instance = new Lazy<CalculationService>(() => new CalculationService());

        public static CalculationService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// Текущий урон героя
        /// </summary>
        public int GetDamage(Character character)
        {
            var characteristics = character.Characteristics;
            int sumAdditionalDamage = characteristics.CurrentBuffs.Count == 0 ? 0 : characteristics.CurrentBuffs.Select(buff => buff.AdditionalDamage).Sum();

            if (character.Weapon == null)
                return sumAdditionalDamage;

            return character.Weapon.Damage + sumAdditionalDamage; // если нет оружия, то нет урона. Думаю нужно добавить оружие "кулаки". когда в слоте weapon - null, будут находится кулаки, которые слабы по урону. Или же добавить на старте меч.
        }

        /// <summary>
        /// Текущая защита героя
        /// </summary>
        public int GetDefence(Character character)
        {
            var characteristics = character.Characteristics;
            int sumAdditionalDefence = characteristics.CurrentBuffs.Count == 0 ? 0 : characteristics.CurrentBuffs.Select(buff => buff.AdditionalDefence).Sum();

            if (character.Armor == null)
                return sumAdditionalDefence;

            return character.Armor.Defence + sumAdditionalDefence;
        }

    }

}
