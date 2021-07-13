using Engine.Data;
using System.Windows.Forms;

namespace GameEditor
{
    public partial class Editor : Form
    {

        private World world;

        public Editor()
        {
            InitializeComponent();
            world = new World();
            world.View = new Engine.Data.View();
        }

        private void InitEditor()
        {
            lstLayout.Items.Clear();

            if (world.Map == null)
                return;

            for (int i = 0; i < world.Map.LayoutCount; i++)
                lstLayout.Items.Add(i);

            lstLayout.SelectedIndex = 0;

            MapService.Instance.DrawMap(world, null /*console*/);
        }


        private void MenuItemNew_Click(object sender, System.EventArgs e)
        {
            var map = MapService.Instance.CreateNewMap();
            if (map == null)
                return;

            world.Map = map;
            InitEditor();
        }

    }

}
