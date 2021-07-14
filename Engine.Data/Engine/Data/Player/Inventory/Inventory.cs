
namespace Engine.Data
{

    /// <summary>
    /// Инвентарь
    /// </summary>
    public class Inventory : IInventory
    {

        private const int INVENTORY_SIZE = 20;


        public IItem[] Items { get; set; } = new Item[INVENTORY_SIZE];

        public int SelectedIndex { get; set; } = 0;

        public IItem Selected { get { return Items[SelectedIndex]; } set { Items[SelectedIndex] = value; } }

    }

}
