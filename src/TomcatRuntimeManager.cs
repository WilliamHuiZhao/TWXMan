using System;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TomcatRuntimeManager : Form
    {
        public TomcatRuntimeManager()
        {
            InitializeComponent();
        }

        private void frmTomcatRuntime_Load(object sender, EventArgs e)
        {
            lvTomcatRuntime.View = System.Windows.Forms.View.Details;
            lvTomcatRuntime.FullRowSelect = true;
            lvTomcatRuntime.GridLines = true;
            lvTomcatRuntime.Sorting = SortOrder.Ascending;

            lvTomcatRuntime.Columns.Add(Constants.Head_TomcatRuntime);
            lvTomcatRuntime.Columns[0].Width = 500;

            TomcatRuntimeConfiguration conf = new TomcatRuntimeConfiguration();
            foreach (string s in conf.GetTomcatRuntimeNames())
            {
                lvTomcatRuntime.Items.Add(s);
            }
        }

        private void btnTomcatRuntimeNew_Click(object sender, EventArgs e)
        {
            TomcatRuntimeWizard dlgTomcat = new TomcatRuntimeWizard();
            if (dlgTomcat.ShowDialog() == DialogResult.Cancel)
                return;

            //
            lvTomcatRuntime.Items.Add(dlgTomcat.TomcatRuntimeName);
        }

        private void btnTomcatRuntimeRemove_Click(object sender, EventArgs e)
        {
            //todo 仅移除了配置并没有删除磁盘上的目录
            if (lvTomcatRuntime.SelectedItems.Count == 1)
            {
                //
                TomcatRuntimeConfiguration conf = new TomcatRuntimeConfiguration();
                conf.RemoveTomcatRuntime(lvTomcatRuntime.SelectedItems[0].Text);

                //
                lvTomcatRuntime.SelectedItems[0].Remove();
            }
        }
    }
}
