using System;
using System.Collections;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXRuntimeManager : Form
    {
        public TWXRuntimeManager()
        {
            InitializeComponent();
        }

        private void TWXRuntimeMgmt_Load(object sender, EventArgs e)
        {
            //设置外观
            lvThingworxRuntime.View = System.Windows.Forms.View.Details;
            lvThingworxRuntime.FullRowSelect = true;
            lvThingworxRuntime.GridLines = true;
            lvThingworxRuntime.Sorting = SortOrder.Ascending;

            lvThingworxRuntime.Columns.Add(Constants.Head_ThingworxRuntime);
            lvThingworxRuntime.Columns.Add(Constants.Head_TomcatRuntime);
            lvThingworxRuntime.Columns[0].Width = 250;
            lvThingworxRuntime.Columns[1].Width = 240;

            //
            DisplayThingworxRuntime();
        }

        private void DisplayThingworxRuntime()
        {
            //清空
            lvThingworxRuntime.Items.Clear();

            //列出所有配置
            ThingworxRuntimeConfiguration twxConfig = new ThingworxRuntimeConfiguration();
            ArrayList arr = twxConfig.ListThingworxRuntime();
            foreach (ThingworxRuntime twx in arr)
            {
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = twx.ThingworxRuntimeName;
                lvitem.SubItems.Add(twx.TomcatRuntimeName);

                lvThingworxRuntime.Items.Add(lvitem);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string strTWXRuntimeName = lvThingworxRuntime.SelectedItems[0].Text;

            if (strTWXRuntimeName != string.Empty)
            {
                ThingworxRuntimeConfiguration twxConfig = new ThingworxRuntimeConfiguration();
                twxConfig.RemoveThingworxRuntime(strTWXRuntimeName);

                lvThingworxRuntime.SelectedItems[0].Remove();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            TWXRuntimeWizard dlgThingworx = new TWXRuntimeWizard();
            dlgThingworx.ShowDialog();

            DisplayThingworxRuntime();
        }
    }
}
