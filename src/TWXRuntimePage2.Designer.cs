
namespace TWXMan
{
    partial class TWXRuntimePage2
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThingworxDBUserPassword = new System.Windows.Forms.TextBox();
            this.txtThingworxDBUserName = new System.Windows.Forms.TextBox();
            this.txtThingworxDatabaseName = new System.Windows.Forms.TextBox();
            this.txtPostgrePort = new System.Windows.Forms.TextBox();
            this.txtPostgreHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Thingworx DB User Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Thingworx DB User Name:";
            // 
            // txtThingworxDBUserPassword
            // 
            this.txtThingworxDBUserPassword.Location = new System.Drawing.Point(196, 184);
            this.txtThingworxDBUserPassword.MaxLength = 60;
            this.txtThingworxDBUserPassword.Name = "txtThingworxDBUserPassword";
            this.txtThingworxDBUserPassword.Size = new System.Drawing.Size(250, 20);
            this.txtThingworxDBUserPassword.TabIndex = 5;
            // 
            // txtThingworxDBUserName
            // 
            this.txtThingworxDBUserName.Location = new System.Drawing.Point(196, 145);
            this.txtThingworxDBUserName.MaxLength = 60;
            this.txtThingworxDBUserName.Name = "txtThingworxDBUserName";
            this.txtThingworxDBUserName.Size = new System.Drawing.Size(250, 20);
            this.txtThingworxDBUserName.TabIndex = 4;
            // 
            // txtThingworxDatabaseName
            // 
            this.txtThingworxDatabaseName.Location = new System.Drawing.Point(196, 106);
            this.txtThingworxDatabaseName.MaxLength = 60;
            this.txtThingworxDatabaseName.Name = "txtThingworxDatabaseName";
            this.txtThingworxDatabaseName.Size = new System.Drawing.Size(250, 20);
            this.txtThingworxDatabaseName.TabIndex = 3;
            // 
            // txtPostgrePort
            // 
            this.txtPostgrePort.Location = new System.Drawing.Point(196, 67);
            this.txtPostgrePort.MaxLength = 5;
            this.txtPostgrePort.Name = "txtPostgrePort";
            this.txtPostgrePort.Size = new System.Drawing.Size(250, 20);
            this.txtPostgrePort.TabIndex = 2;
            this.txtPostgrePort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostgrePort_KeyPress);
            // 
            // txtPostgreHostName
            // 
            this.txtPostgreHostName.Location = new System.Drawing.Point(196, 28);
            this.txtPostgreHostName.MaxLength = 60;
            this.txtPostgreHostName.Name = "txtPostgreHostName";
            this.txtPostgreHostName.Size = new System.Drawing.Size(250, 20);
            this.txtPostgreHostName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Thingworx Database Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "PostgreSQL DB Port Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "PostgreSQL IP or Host Name:";
            // 
            // TWXRuntimePage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtThingworxDBUserPassword);
            this.Controls.Add(this.txtThingworxDBUserName);
            this.Controls.Add(this.txtThingworxDatabaseName);
            this.Controls.Add(this.txtPostgrePort);
            this.Controls.Add(this.txtPostgreHostName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TWXRuntimePage2";
            this.Text = "TWXPage2";
            this.Load += new System.EventHandler(this.TWXPage2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThingworxDBUserPassword;
        private System.Windows.Forms.TextBox txtThingworxDBUserName;
        private System.Windows.Forms.TextBox txtThingworxDatabaseName;
        private System.Windows.Forms.TextBox txtPostgrePort;
        private System.Windows.Forms.TextBox txtPostgreHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}