
namespace Engine.Data
{

    public enum CharacterType : int
    {

        /// <summary>
        /// Животное - Дружелюбен к животным, остальные для него враги
        /// </summary>
        Animal    = 0x00,

        /// <summary>
        /// Человек - дружелюбный к другим людям, остальные для него враги
        /// </summary>
        Human     = 0x01,

        /// <summary>
        /// Все существа для него враги, кроме таких же варваров
        /// </summary>
        Barbarian = 0x02,

    }

}
