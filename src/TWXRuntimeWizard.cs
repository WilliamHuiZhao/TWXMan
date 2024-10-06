using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXRuntimeWizard : Form
    {
        private List<Form> form_list = new List<Form>();
        private TWXRuntimePage1 page1 = new TWXRuntimePage1();
        private TWXRuntimePage2 page2 = new TWXRuntimePage2();
        private TWXRuntimePage3 page3 = new TWXRuntimePage3();
        private int pageIndex = 0;
        private int FIRST_PAGE = 0;
        private int LAST_PAGE = 2;

        public TWXRuntimeWizard()
        {
            InitializeComponent();
        }

        private void frmThingworxWizardMain_Load(object sender, EventArgs e)
        {
            //将Page1、2、3都放到Panel中
            page1.TopLevel = false;
            page1.Parent = panel1;
            page1.Dock = DockStyle.Fill;

            page2.TopLevel = false;
            page2.Parent = panel1;
            page2.Dock = DockStyle.Fill;

            page3.TopLevel = false;
            page3.Parent = panel1;
            page3.Dock = DockStyle.Fill;

            form_list.Add(page1);
            form_list.Add(page2);
            form_list.Add(page3);

            ShowPage();
            DisplayButtons();
        }

        private void ShowPage()
        {
            //除了当前页的窗体展示，以外其余窗体都隐藏
            for (int i = 0; i < form_list.Count; i++)
            {
                if (i == pageIndex)
                    form_list[i].Show();
                else
                    form_list[i].Hide();
            }
        }

        private void DisplayButtons()
        {
            if (pageIndex == FIRST_PAGE)
            {
                btnBack.Enabled = false;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
            }
            else if (pageIndex == LAST_PAGE)
            {
                btnBack.Enabled = true;
                btnNext.Enabled = false;
                btnFinish.Enabled = true;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
            }
        }

        private bool checkValues()
        {
            //检查
            if (page1.ThingworxRuntimeName == string.Empty)
            {
                MessageBox.Show("Thingworx Runtime Name is empty");
                return false;
            }

            if (page1.ThingworxPackage == "")
            {
                MessageBox.Show("Thingworx Package is empty");
                return false;
            }

            if (page1.ThingworxInstallationFolder == "")
            {
                MessageBox.Show("Thingworx Installation Folder is empty");
                return false;
            }

            if (page1.TomcatRuntimeName == "")
            {
                MessageBox.Show("Tomcat Runtime is empty");
                return false;
            }

            if (page2.PostgreHostName == "")
            {
                MessageBox.Show("PostgreSQL IP or Host Name is empty");
                return false;
            }

            if (page2.PostgrePort == "")
            {
                MessageBox.Show("PostgreSQL DB Port Number is empty");
                return false;
            }

            if (page2.ThingworxDatabaseName == "")
            {
                MessageBox.Show("Thingworx Database Name is empty");
                return false;
            }

            if (page2.ThingworxDBUserName == "")
            {
                MessageBox.Show("Thingworx DB User Name is empty");
                return false;
            }

            if (page2.ThingworxDBUserPassword == "")
            {
                MessageBox.Show("Thingworx DB User Password is empty");
                return false;
            }

            return true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pageIndex--;

            DisplayButtons();

            ShowPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex++;

            DisplayButtons();

            ShowPage();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //
            if (checkValues() == false) return;

            //
            ThingworxRuntime twxRuntime = new ThingworxRuntime();

            twxRuntime.ThingworxRuntimeName = page1.ThingworxRuntimeName;
            twxRuntime.ThingworxPackage = page1.ThingworxPackage;
            twxRuntime.ThingworxInstallationFolder = page1.ThingworxInstallationFolder;
            twxRuntime.TomcatRuntimeName = page1.TomcatRuntimeName;
            twxRuntime.PostgreHostName = page2.PostgreHostName;
            twxRuntime.PostgrePort = page2.PostgrePort;
            twxRuntime.ThingworxDatabaseName = page2.ThingworxDatabaseName;
            twxRuntime.ThingworxDBUserName = page2.ThingworxDBUserName;
            twxRuntime.ThingworxDBUserPassword = page2.ThingworxDBUserPassword;

            //判断当前设置是否存在
            ThingworxRuntimeConfiguration twxConfiguration = new ThingworxRuntimeConfiguration();
            if (twxConfiguration.IsExist(page1.ThingworxRuntimeName))
            {
                MessageBox.Show("Thingworx Runtime already exists, please change it.");
                return;
            }

            //保存设置
            twxConfiguration.AppendThingworxRuntime(twxRuntime);

            //如果存在则删除
            if (Directory.Exists(page1.ThingworxInstallationFolder) == true)
            {
                if (MessageBox.Show(page1.ThingworxInstallationFolder + @" already existed, delete it or not ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.Delete(page1.ThingworxInstallationFolder, true);
                    }
                    catch
                    {
                    }
                }
            }

            //构建Thingworx环境
            twxRuntime.BuildThingworx();

            //
            this.DialogResult = DialogResult.OK;
        }
    }
}
