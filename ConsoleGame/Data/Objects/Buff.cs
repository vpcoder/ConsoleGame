using System;
using System.Collections.Generic;

namespace Engine.Data
{
    public class Buff
    {
        public Buff(int IDBuff)    //Должно быть у любого баффа!
        {
            this.IDBuff = IDBuff;
        }
        public int IDBuff { get; set; }    //ID для проверки на уникальность баффа
        public int Duration { get; set; }   //Длительность баффа
        public bool EndlessBuff { get; set; } = false;   //Является ли бафф бесконечным
        public int AdditionalHP { get; set; }   // Доп. хп
        public int AdditionalDamage { get; set; }   // Доп. урон
        public int AdditionalDefence { get; set; }  //Доп. защита

    }
}
