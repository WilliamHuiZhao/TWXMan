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
    public partial class TomcatRuntimePage1 : Form
    {
        public TomcatRuntimePage1()
        {
            InitializeComponent();
        }

        public string TomcatRuntimeName
        {
            get
            {
                return txtTomcatRuntimeName.Text.Trim();
            }
        }

        public string TomcatRuntimeDescription
        {
            get
            {
                return txtDescription.Text.Trim();
            }
        }

        public string TomcatRuntimeZip
        {
            get
            {
                return MyDir.TomcatFullDir + cmbTomcatPackage.Text.Trim();
            }
        }

        public string TomcatHome
        {
            get
            {
                return txtTomcatHome.Text.Trim();
            }
        }

        private void TomcatRuntimePage1_Load(object sender, EventArgs e)
        {
            //显示所有的Tomcat安装包
            foreach (string package in MyDir.ListTomcatPackages())
            {
                cmbTomcatPackage.Items.Add(package);
            }

            //
            txtTomcatHome.Text = Application.StartupPath + @"\";
        }

        private void txtTomcatRuntimeName_TextChanged(object sender, EventArgs e)
        {
            txtTomcatHome.Text = Application.StartupPath + @"\" + txtTomcatRuntimeName.Text.Trim() + @"\";
        }
    }
}
