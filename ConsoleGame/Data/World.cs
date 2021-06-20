
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
        public Map Map { get; set; }

        /// <summary>
        /// Персонаж
        /// </summary>
        public Player Player { get; set; }

    }

}
