
namespace Engine.Data
{

    /// <summary>
    /// Инвентарь
    /// </summary>
    public interface IInventory
    {

        IItem[] Items { get; set; }

        int SelectedIndex { get; set; }

        IItem Selected { get; set; }

    }

}
