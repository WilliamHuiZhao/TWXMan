
namespace TWXMan
{
    partial class TomcatRuntimePage1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTomcatRuntimeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTomcatPackage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTomcatHome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tomcat Runtime Name:";
            // 
            // txtTomcatRuntimeName
            // 
            this.txtTomcatRuntimeName.Location = new System.Drawing.Point(157, 29);
            this.txtTomcatRuntimeName.MaxLength = 32;
            this.txtTomcatRuntimeName.Name = "txtTomcatRuntimeName";
            this.txtTomcatRuntimeName.Size = new System.Drawing.Size(294, 20);
            this.txtTomcatRuntimeName.TabIndex = 1;
            this.txtTomcatRuntimeName.TextChanged += new System.EventHandler(this.txtTomcatRuntimeName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(157, 66);
            this.txtDescription.MaxLength = 32;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(294, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tomcat Package:";
            // 
            // cmbTomcatPackage
            // 
            this.cmbTomcatPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTomcatPackage.FormattingEnabled = true;
            this.cmbTomcatPackage.Location = new System.Drawing.Point(157, 102);
            this.cmbTomcatPackage.Name = "cmbTomcatPackage";
            this.cmbTomcatPackage.Size = new System.Drawing.Size(294, 21);
            this.cmbTomcatPackage.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tomcat Home:";
            // 
            // txtTomcatHome
            // 
            this.txtTomcatHome.Location = new System.Drawing.Point(157, 141);
            this.txtTomcatHome.MaxLength = 256;
            this.txtTomcatHome.Name = "txtTomcatHome";
            this.txtTomcatHome.ReadOnly = true;
            this.txtTomcatHome.Size = new System.Drawing.Size(294, 20);
            this.txtTomcatHome.TabIndex = 18;
            // 
            // TomcatRuntimePage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 250);
            this.Controls.Add(this.txtTomcatHome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTomcatPackage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTomcatRuntimeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TomcatRuntimePage1";
            this.Text = "TomcatRuntimePage1";
            this.Load += new System.EventHandler(this.TomcatRuntimePage1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTomcatRuntimeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTomcatPackage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTomcatHome;
    }
}