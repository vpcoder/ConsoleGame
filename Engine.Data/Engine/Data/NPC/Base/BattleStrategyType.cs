
namespace Engine.Data
{

    /// <summary>
    /// Стратегия сражения
    /// </summary>
    public enum BattleStrategyType : int
    {

        /// <summary>
        /// Держаться рядом с целью
        /// </summary>
        Near = 0x00,

        /// <summary>
        /// Держаться на расстоянии от цели
        /// </summary>
        Far  = 0x01,

    };

}
