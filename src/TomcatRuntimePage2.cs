using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TomcatRuntimePage2 : Form
    {
        public TomcatRuntimePage2()
        {
            InitializeComponent();
        }

        public string TomcatPort
        {
            get
            {
                return txtTomcatPort.Text.Trim();
            }
        }

        public string TomcatSetEnv
        {
            get
            {
                return chkSetTomcatForThingworx.Checked.ToString();
            }
        }

        private void txtTomcatPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
        }

        private void TomcatRuntimePage2_Load(object sender, EventArgs e)
        {
            //缺省端口
            txtTomcatPort.Text = Constants.TomcatPort.ToString();

            //
            chkSetTomcatForThingworx.Checked = true;
        }
    }
}
