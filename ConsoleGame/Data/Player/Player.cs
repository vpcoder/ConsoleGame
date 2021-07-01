using System;
using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Базовый класс игрока
    /// </summary>
    public class Player : SpriteChar
    {

        public Player()
        {
            this.Color = ConsoleColor.White;
            this.Symbol = '☺';
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
        public List<Buff> CurrentBuffs = new List<Buff>();

        public void AddBuff(Buff buff)
        {
            if (CurrentBuffs.Count == 0) CurrentBuffs.Add(buff);
            for (int i = 0; i < CurrentBuffs.Count; i++)
            {
                if (CurrentBuffs[i].IDBuff != buff.IDBuff) CurrentBuffs.Add(buff);//Скорей всего от этого можно избавиться, но через IndexOF и IndexFind у меня не вышло
                
            }
        }


        // РЕАЛИЗОВАТЬ 
        
        /// <summary>
        /// Текущий урон героя
        /// </summary>
        public int Damage
        {
            get
            {
                List<int> usedIDs = new List<int>();
                int sumAdditionalDamage = 0;
                
               
                foreach (var elem in CurrentBuffs)
                {

                    if (!usedIDs.Contains(elem.IDBuff))
                    {
                        sumAdditionalDamage += elem.AdditionalDamage;
                        usedIDs.Add(elem.IDBuff);
                    }
                    
                    
                }
                if (Weapon != null) return Weapon.Damage + sumAdditionalDamage; // если нет оружия, то нет урона. Думаю нужно добавить оружие "кулаки". когда в слоте weapon - null, будут находится кулаки, которые слабы по урону. Или же добавить на старте меч.
                else return 0;
            }
        }

        /// <summary>
        /// Текущая защита героя
        /// </summary>
        public int Defence
        {
            get
            {
                List<int> usedIDs = new List<int>();
                int sumAdditionalDefence = 0;


                foreach (var elem in CurrentBuffs)
                {

                    if (!usedIDs.Contains(elem.IDBuff))
                    {
                        sumAdditionalDefence += elem.AdditionalDamage;
                        usedIDs.Add(elem.IDBuff);
                    }



                }
                if (Armor != null) return Armor.Defence + sumAdditionalDefence;
                else return 0 + sumAdditionalDefence;
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
