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

        /// <summary>
        /// Выполняет нанесение урона от source к target
        /// </summary>
        /// <param name="source">Тот кто наносит урон</param>
        /// <param name="bullet">Снаряд, если используется (null, если не используется)</param>
        /// <param name="target">Тот кто получает урон</param>
        public void DoDamage(ICharacter source, IBullet bullet, ICharacter target)
        {
            var damage = GetDamage(source); // Получаем урон, который нужно наносить
            if (bullet != null)
                damage += bullet.Damage; // Если это снаряд, добавляем урон от снаряда

            var defence = GetDefence(target); // Получаем защиту оппонента

            damage -= defence; // Получаем урон, который пройдёт через защиту
            if (damage < 0) // Урона было недостаточно...
                return;

            target.Characteristics.Health -= damage; // Наносим урон
        }

        // <summary>
        /// Выполняет нанесение урона от source к target
        /// </summary>
        /// <param name="source">Тот кто наносит урон</param>
        /// <param name="target">Тот кто получает урон</param>
        public void DoDamage(ICharacter source, ICharacter target)
        {
            DoDamage(source, null, target);
        }

    }

}
