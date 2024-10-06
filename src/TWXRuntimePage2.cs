using System;
using System.Windows.Forms;

namespace TWXMan
{
    public partial class TWXRuntimePage2 : Form
    {
        public TWXRuntimePage2()
        {
            InitializeComponent();
        }

        #region 界面上的设置属性
        public string PostgreHostName
        {
            get
            {
                return this.txtPostgreHostName.Text;
            }
        }

        public string PostgrePort
        {
            get
            {
                return this.txtPostgrePort.Text;
            }
        }

        public string ThingworxDatabaseName
        {
            get
            {
                return this.txtThingworxDatabaseName.Text;
            }
        }

        public string ThingworxDBUserName
        {
            get
            {
                return this.txtThingworxDBUserName.Text;
            }
        }

        public string ThingworxDBUserPassword
        {
            get
            {
                return this.txtThingworxDBUserPassword.Text;
            }
        }
        #endregion

        private void TWXPage2_Load(object sender, EventArgs e)
        {
            txtPostgreHostName.Text = Public.GetHostName();
            txtPostgrePort.Text = Constants.PostgrePort.ToString();

            txtThingworxDBUserName.Text = Constants.ThingworxDBUserName;
            txtThingworxDBUserPassword.Text = Constants.ThingworxDBUserPassword;
        }

        private void txtPostgrePort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
        }
    }
}
