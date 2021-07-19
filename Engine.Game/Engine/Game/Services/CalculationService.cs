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

        #region Singleton

        private static Lazy<CalculationService> instance = new Lazy<CalculationService>(() => new CalculationService());

        public static CalculationService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private CalculationService() { }

        #endregion

        /// <summary>
        /// Текущий урон персонажа/НПС
        /// </summary>
        public int GetDamage(ICharacter character)
        {
            var characteristics = character.Characteristics;
            int sumAdditionalDamage = characteristics.BaseDamage;
            sumAdditionalDamage += characteristics.CurrentBuffs.Count == 0 ? 0 : characteristics.CurrentBuffs.Select(buff => buff.AdditionalDamage).Sum();

            if (character.Weapon == null)
                return sumAdditionalDamage;

            return character.Weapon.Damage + sumAdditionalDamage; // если нет оружия, то нет урона. Думаю нужно добавить оружие "кулаки". когда в слоте weapon - null, будут находится кулаки, которые слабы по урону. Или же добавить на старте меч.
        }

        /// <summary>
        /// Текущая защита персонажа/НПС
        /// </summary>
        public int GetDefence(ICharacter character)
        {
            var characteristics = character.Characteristics;
            int sumAdditionalDefence = characteristics.BaseDefence;
            sumAdditionalDefence += characteristics.CurrentBuffs.Count == 0 ? 0 : characteristics.CurrentBuffs.Select(buff => buff.AdditionalDefence).Sum();

            if (character.Armor == null)
                return sumAdditionalDefence;

            return character.Armor.Defence + sumAdditionalDefence;
        }

    }

}
