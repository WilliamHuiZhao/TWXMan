
namespace TWXMan
{
    partial class TWXRuntimePage1
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
            this.txtThingworxInstallationFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThingworxRuntimeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTomcatRuntimeName = new System.Windows.Forms.ComboBox();
            this.cmbThingworxPackage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtThingworxInstallationFolder
            // 
            this.txtThingworxInstallationFolder.Location = new System.Drawing.Point(185, 104);
            this.txtThingworxInstallationFolder.Name = "txtThingworxInstallationFolder";
            this.txtThingworxInstallationFolder.ReadOnly = true;
            this.txtThingworxInstallationFolder.Size = new System.Drawing.Size(250, 20);
            this.txtThingworxInstallationFolder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Thingworx Installation Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Thingworx Package:";
            // 
            // txtThingworxRuntimeName
            // 
            this.txtThingworxRuntimeName.Location = new System.Drawing.Point(185, 28);
            this.txtThingworxRuntimeName.MaxLength = 20;
            this.txtThingworxRuntimeName.Name = "txtThingworxRuntimeName";
            this.txtThingworxRuntimeName.Size = new System.Drawing.Size(250, 20);
            this.txtThingworxRuntimeName.TabIndex = 1;
            this.txtThingworxRuntimeName.TextChanged += new System.EventHandler(this.txtThingworxRuntimeName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Thingworx Runtime Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tomcat Runtime Name:";
            // 
            // cmbTomcatRuntimeName
            // 
            this.cmbTomcatRuntimeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTomcatRuntimeName.FormattingEnabled = true;
            this.cmbTomcatRuntimeName.Location = new System.Drawing.Point(185, 142);
            this.cmbTomcatRuntimeName.Name = "cmbTomcatRuntimeName";
            this.cmbTomcatRuntimeName.Size = new System.Drawing.Size(250, 21);
            this.cmbTomcatRuntimeName.TabIndex = 5;
            // 
            // cmbThingworxPackage
            // 
            this.cmbThingworxPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThingworxPackage.DropDownWidth = 350;
            this.cmbThingworxPackage.FormattingEnabled = true;
            this.cmbThingworxPackage.Location = new System.Drawing.Point(185, 67);
            this.cmbThingworxPackage.Name = "cmbThingworxPackage";
            this.cmbThingworxPackage.Size = new System.Drawing.Size(250, 21);
            this.cmbThingworxPackage.TabIndex = 22;
            // 
            // TWXRuntimePage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.cmbThingworxPackage);
            this.Controls.Add(this.cmbTomcatRuntimeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThingworxInstallationFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtThingworxRuntimeName);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TWXRuntimePage1";
            this.Text = "TWXPage1";
            this.Load += new System.EventHandler(this.TWXPage1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtThingworxInstallationFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThingworxRuntimeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTomcatRuntimeName;
        private System.Windows.Forms.ComboBox cmbThingworxPackage;
    }
}