using System;
using System.Threading;
using System.Windows.Forms;

namespace Test
{

    public static class Program
    {

        //[STAThread]
        public static void Main(string[] args)
        {
            var form = new Form1();
            Application.Run(form);
        }

    }

}
