
namespace Engine.Data
{

    public class Inventory
    {

        public Item[] Items { get; set; } = new Item[20];

        public int SelectedIndex { get; set; } = 0;

        public Item Selected { get { return Items[SelectedIndex]; } set { Items[SelectedIndex] = value; } }

    }

}
