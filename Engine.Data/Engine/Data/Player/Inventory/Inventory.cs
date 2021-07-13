
namespace Engine.Data
{

    public class Inventory
    {

        private const int INVENTORY_SIZE = 20;


        public Item[] Items { get; set; } = new Item[INVENTORY_SIZE];

        public int SelectedIndex { get; set; } = 0;

        public Item Selected { get { return Items[SelectedIndex]; } set { Items[SelectedIndex] = value; } }

    }

}
