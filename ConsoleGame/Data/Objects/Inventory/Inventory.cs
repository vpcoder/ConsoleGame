
namespace Engine.Data
{

    public class Inventory
    {

        public Item[] Items { get; set; } = new Item[20];

        public int SelectedIndex { get; set; } = 0;

    }

}
