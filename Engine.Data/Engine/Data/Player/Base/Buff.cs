using System;

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

        public bool EndlessBuff { get; set; } = false; // Является ли бафф бесконечным

        public int AdditionalHealth { get; set; } // Доп. хп

        public int AdditionalDamage { get; set; } // Доп. урон

        public int AdditionalDefence { get; set; }  //Доп. защита

        public override int GetHashCode()
        {
            return IDBuff;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Buff another = obj as Buff;
            if(another == null)
                return false;
            return IDBuff == another.IDBuff;
        }

    }

}
