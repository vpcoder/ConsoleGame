using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 200;
            timer.Tick += (o, e) => {
                test.Refresh();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

    }

}
