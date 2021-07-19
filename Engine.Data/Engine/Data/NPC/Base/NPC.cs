
namespace Engine.Data
{

    public abstract class NPC : Character, INPC
    {

        /// <summary>
        /// Имя НПС
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цель охоты этого НПС, если не на кого охотится - null
        /// </summary>
        public ICharacter Target { get; set; }

        /// <summary>
        /// Стратегия битвы
        /// </summary>
        public BattleStrategyType Strategy { get; set; }

        /// <summary>
        /// В каком радиусе от точки интереса NPC гуляет
        /// </summary>
        public int MoveRadius { get; set; }

        /// <summary>
        /// Радиус агрессии у НПС, всё что попадает в этот радиус от его текущего местоположения,
        /// и что является враждебным к НПС - должно стать его целью Target
        /// </summary>
        public int AgressionRadius { get; set; }

        /// <summary>
        /// Точка интереса - НПС крутиться вокруг неё
        /// </summary>
        public Vector2 IntrestingPoint { get; set; }

        /// <summary>
        /// Следующая точка, куда NPC хотел бы сходить
        /// </summary>
        public Vector2 NextPoint { get; set; }

        /// <summary>
        /// Время, через которое NPC решит пойти в новую точку
        /// </summary>
        public double NextPointChangeTime { get; set; }

        /// <summary>
        /// Время последнего действия НПС
        /// </summary>
        public double LastUpdateTime { get; set; }

    }

}
