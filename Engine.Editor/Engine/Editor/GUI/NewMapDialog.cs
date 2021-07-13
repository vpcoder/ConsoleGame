using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameEditor
{

    public partial class NewMapDialog : Form
    {

        public string MapName
        {
            get
            {
                return txtName.Text;
            }
        }

        public Size MapSize
        {
            get
            {
                var data = txtSize.Text.ToLower().Split('x');
                return new Size(int.Parse(data[0]), int.Parse(data[1]));
            }
        }

        public NewMapDialog()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var data = txtSize.Text.ToLower().Split('x');
                var size = new Size(int.Parse(data[0]), int.Parse(data[1]));

                if (size.Width <= 0 || size.Height <= 0)
                    throw new ArgumentException("Размер не может быть меньше или равен 0 по любой из оси!");

                if (size.Width > 1000 || size.Height > 1000)
                    throw new ArgumentException("Размер не может быть больше 1000 по любой из оси!");

                if (MapName == null || MapName.Length == 0)
                    throw new ArgumentException("Имя карты не может быть пустым!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = DialogResult.OK;
        }

    }

}
