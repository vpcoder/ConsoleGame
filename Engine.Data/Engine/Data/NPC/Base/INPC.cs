

namespace Engine.Data
{

    public interface INPC : ICharacter
    {

        /// <summary>
        /// Имя НПС
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Цель охоты этого НПС, если не на кого охотится - null
        /// </summary>
        ICharacter Target { get; set; }

        /// <summary>
        /// Стратегия битвы
        /// </summary>
        BattleStrategyType Strategy { get; set; }

        /// <summary>
        /// В каком радиусе от точки интереса NPC гуляет
        /// </summary>
        int MoveRadius { get; set; }

        /// <summary>
        /// Радиус агрессии у НПС, всё что попадает в этот радиус от его текущего местоположения,
        /// и что является враждебным к НПС - должно стать его целью Target
        /// </summary>
        int AgressionRadius { get; set; }

        /// <summary>
        /// Точка интереса - НПС крутиться вокруг неё
        /// </summary>
        Vector2 IntrestingPoint { get; set; }

        /// <summary>
        /// Следующая точка, куда NPC хотел бы сходить
        /// </summary>
        Vector2 NextPoint { get; set; }

        /// <summary>
        /// Время последнего действия НПС
        /// </summary>
        double LastUpdateTime { get; set; }

        /// <summary>
        /// Время, через которое NPC решит пойти в новую точку
        /// </summary>
        double NextPointChangeTime { get; set; }

    }

}
