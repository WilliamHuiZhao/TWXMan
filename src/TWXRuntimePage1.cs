using System;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXRuntimePage1 : Form
    {
        public TWXRuntimePage1()
        {
            InitializeComponent();
        }

        private void TWXPage1_Load(object sender, EventArgs e)
        {
            //
            txtThingworxInstallationFolder.Text = Application.StartupPath + @"\";

            //显示所有的TomcatRuntimeName
            TomcatRuntimeConfiguration tomcatconf = new TomcatRuntimeConfiguration();
            foreach (string str in tomcatconf.GetTomcatRuntimeNames())
            {
                cmbTomcatRuntimeName.Items.Add(str);
            }

            //显示所有的Thingworx手工安装包
            foreach (string package in MyDir.ListThingworxPackages(Application.StartupPath))
            {
                cmbThingworxPackage.Items.Add(package);
            }

        }

        #region Thingworx的配置属性
        public string ThingworxRuntimeName
        {
            get
            {
                return this.txtThingworxRuntimeName.Text.Trim();
            }
        }

        public string ThingworxPackage
        {
            get
            {
                string s = MyDir.ThingworxFullDir + this.cmbThingworxPackage.Text;
                return s.Trim();
            }
        }

        public string ThingworxInstallationFolder
        {
            get
            {
                return this.txtThingworxInstallationFolder.Text.Trim();
            }
        }

        public string TomcatRuntimeName
        {
            get
            {
                return this.cmbTomcatRuntimeName.Text.Trim();
            }
        }
        #endregion

        private void txtThingworxRuntimeName_TextChanged(object sender, EventArgs e)
        {
            txtThingworxInstallationFolder.Text = Application.StartupPath + @"\" + ThingworxRuntimeName + @"\";
        }
    }
}
