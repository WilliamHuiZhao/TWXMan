using System;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXRuntimePage3 : Form
    {
        public TWXRuntimePage3()
        {
            InitializeComponent();
        }

        private void TWXPage3_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Summary\n\n"
                + "-createdb.bat, used for creating database.\n\n"
                + "-start.bat, start Thingworx.\n\n"
                + "-stop.bat, stop Thingworx.";
        }
    }
}
