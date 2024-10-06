
namespace TWXMan
{
    partial class TomcatRuntimePage2
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
            this.chkSetTomcatForThingworx = new System.Windows.Forms.CheckBox();
            this.txtTomcatPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkSetTomcatForThingworx
            // 
            this.chkSetTomcatForThingworx.AutoSize = true;
            this.chkSetTomcatForThingworx.Checked = true;
            this.chkSetTomcatForThingworx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetTomcatForThingworx.Location = new System.Drawing.Point(35, 66);
            this.chkSetTomcatForThingworx.Name = "chkSetTomcatForThingworx";
            this.chkSetTomcatForThingworx.Size = new System.Drawing.Size(148, 17);
            this.chkSetTomcatForThingworx.TabIndex = 24;
            this.chkSetTomcatForThingworx.Text = "Set Tomcat for Thingworx";
            this.chkSetTomcatForThingworx.UseVisualStyleBackColor = true;
            // 
            // txtTomcatPort
            // 
            this.txtTomcatPort.Location = new System.Drawing.Point(157, 25);
            this.txtTomcatPort.MaxLength = 5;
            this.txtTomcatPort.Name = "txtTomcatPort";
            this.txtTomcatPort.Size = new System.Drawing.Size(233, 20);
            this.txtTomcatPort.TabIndex = 23;
            this.txtTomcatPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTomcatPort_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Tomcat Port:";
            // 
            // TomcatRuntimePage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.chkSetTomcatForThingworx);
            this.Controls.Add(this.txtTomcatPort);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TomcatRuntimePage2";
            this.Text = "TomcatRuntimePage2";
            this.Load += new System.EventHandler(this.TomcatRuntimePage2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSetTomcatForThingworx;
        private System.Windows.Forms.TextBox txtTomcatPort;
        private System.Windows.Forms.Label label5;
    }
}