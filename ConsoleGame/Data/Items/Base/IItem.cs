
namespace Engine.Data
{

    public interface IItem : ISprite
    {

        bool IsQuestItem { get; set; }

        int StackSize { get; set; }

        int MaxStackSize { get; set; }

        string Title { get; set; }

        string Description { get; set; }

    }

}
