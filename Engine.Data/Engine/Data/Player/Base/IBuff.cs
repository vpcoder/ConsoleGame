
namespace Engine.Data
{

    public interface IBuff
    {

        int IDBuff { get; set; }    //ID для проверки на уникальность баффа

        int Duration { get; set; }   //Длительность баффа

        bool EndlessBuff { get; set; } // Является ли бафф бесконечным

        int AdditionalHealth { get; set; } // Доп. хп

        int AdditionalDamage { get; set; } // Доп. урон

        int AdditionalDefence { get; set; }  //Доп. защита

    }

}
