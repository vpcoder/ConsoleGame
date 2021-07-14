
namespace Engine.Data
{

    public abstract class Armor : Item, IArmor
    {

        /// <summary>
        /// Параметр защиты брони
        /// </summary>
        public int Defence { get; set; }

    }

}
