
using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Класс мира, включающий в себя персонажа, карту, врагов, предметы и прочее...
    /// </summary>
    public class World
    {

        /// <summary>
        /// Карта
        /// </summary>
        public Map Map { get; } = new Map();

        /// <summary>
        /// Видимая часть мира (рамка карты)
        /// </summary>
        public View View { get; } = new View();

        /// <summary>
        /// Снаряды в нашем мире
        /// </summary>
        public ICollection<IBullet> Bullets { get; } = new HashSet<IBullet>();

        /// <summary>
        /// НПС в нашем мире
        /// </summary>
        public ICollection<INPC> NPCs { get; } = new HashSet<INPC>();

        /// <summary>
        /// Персонаж
        /// </summary>
        public Player Player { get; } = new Player();

    }

}
