using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TWXMan
{
    public partial class TomcatRuntimeWizard : Form
    {
        private List<Form> form_list = new List<Form>();
        private TomcatRuntimePage1 page1 = new TomcatRuntimePage1();
        private TomcatRuntimePage2 page2 = new TomcatRuntimePage2();
        private TomcatRuntimePage3 page3 = new TomcatRuntimePage3();
        private int pageIndex = 0;
        private int FIRST_PAGE = 0;
        private int LAST_PAGE = 1;

        public TomcatRuntimeWizard()
        {
            InitializeComponent();
        }

        private void TomcatRuntimeWizard_Load(object sender, EventArgs e)
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

        private bool checkValues()
        {
            //检查page1上的值
            if (page1.TomcatRuntimeName == string.Empty)
            {
                MessageBox.Show("Tomcat Runtime Name is empty");
                return false;
            }

            //txtDescription is optional

            //
            if (page1.TomcatRuntimeZip == string.Empty)
            {
                MessageBox.Show("Tomcat Package is empty");
                return false;
            }

            if (page1.TomcatHome == string.Empty)
            {
                MessageBox.Show("Tomcat Home is empty");
                return false;
            }
            else
            {
                //如果tomcat目录已经存在
                if (Directory.Exists(page1.TomcatHome) == true)
                {
                    if (MessageBox.Show("Tomcat folder already exists, delete it or not?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.Delete(page1.TomcatHome, true);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //检查page2上的值
            if (page2.TomcatPort == string.Empty)
            {
                MessageBox.Show("Tomcat Port is empty");
                return false;
            }
            else
            {
                //利用正则表达式判断是否输入的是数字
                Regex regex = new Regex("^[0-9]*$");

                if (regex.IsMatch(page2.TomcatPort))
                {
                    try
                    {
                        int num = int.Parse(page2.TomcatPort);
                    }
                    catch
                    {
                        MessageBox.Show("Tomcat Port is not correct");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Tomcat Port is not correct, suggest to use 80/8080");
                    return false;
                }
            }

            return true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //
            if (checkValues() == false) return;

            //判断设置是否已经存在
            TomcatRuntimeConfiguration conf = new TomcatRuntimeConfiguration();
            if (conf.IsExist(page1.TomcatRuntimeName))
            {
                MessageBox.Show("Tomcat Runtime Name already exists, please change Tomcat Runtime Name");
                return;
            }

            //保存当前
            conf.AppendTomcatRuntime(page1.TomcatRuntimeName,
                page1.TomcatRuntimeDescription,
                page1.TomcatRuntimeZip,
                page1.TomcatHome,
                page2.TomcatPort,
                page2.TomcatSetEnv);

            //把tomcat的压缩包解压到指定的文件夹
            Public.ExtractTomcat(page1.TomcatRuntimeZip, page1.TomcatHome);

            //修改tomcat的设置
            Public.ChangeTomcatPort(page1.TomcatHome, page2.TomcatPort);
            Public.CreateTomcatSetEnvFile(page1.TomcatHome);

            //
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string TomcatRuntimeName
        {
            get
            {
                return page1.TomcatRuntimeName;
            }
        }
    }
}
