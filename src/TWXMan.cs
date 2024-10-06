using System;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXMan : Form
    {
        public TWXMan()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTWXMan_Load(object sender, EventArgs e)
        {
            //初始化目录结构
            MyDir.InitAppFolders(Application.StartupPath);
        }

        private void tomcatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TomcatRuntimeWizard dlgTomcat = new TomcatRuntimeWizard();
            dlgTomcat.ShowDialog();
        }

        private void thingWorxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TWXRuntimeWizard dlgThingworx = new TWXRuntimeWizard();
            dlgThingworx.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //管理ThingworxRuntimeConfiguration
            TWXRuntimeManager dlgTWXRuntimeMgmt = new TWXRuntimeManager();
            dlgTWXRuntimeMgmt.ShowDialog();
        }

        private void tomcatRuntimeManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TomcatRuntimeManager dlgTomcatRuntime = new TomcatRuntimeManager();
            dlgTomcatRuntime.ShowDialog();
        }
    }
}
