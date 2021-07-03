using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class TestComponent : UserControl, IConsole
    {

        // world ?
        private static readonly Pen pen = new Pen(Color.Red);
        private static readonly Brush background = new SolidBrush(Color.Black);

        public TestComponent()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);

        }

        private void TestComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
