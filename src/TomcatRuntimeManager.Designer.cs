
namespace TWXMan
{
    partial class TomcatRuntimeManager
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
            this.btnTomcatRuntimeNew = new System.Windows.Forms.Button();
            this.btnTomcatRuntimeRemove = new System.Windows.Forms.Button();
            this.lvTomcatRuntime = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnTomcatRuntimeNew
            // 
            this.btnTomcatRuntimeNew.Location = new System.Drawing.Point(518, 12);
            this.btnTomcatRuntimeNew.Name = "btnTomcatRuntimeNew";
            this.btnTomcatRuntimeNew.Size = new System.Drawing.Size(75, 23);
            this.btnTomcatRuntimeNew.TabIndex = 0;
            this.btnTomcatRuntimeNew.Text = "New...";
            this.btnTomcatRuntimeNew.UseVisualStyleBackColor = true;
            this.btnTomcatRuntimeNew.Click += new System.EventHandler(this.btnTomcatRuntimeNew_Click);
            // 
            // btnTomcatRuntimeRemove
            // 
            this.btnTomcatRuntimeRemove.Location = new System.Drawing.Point(518, 41);
            this.btnTomcatRuntimeRemove.Name = "btnTomcatRuntimeRemove";
            this.btnTomcatRuntimeRemove.Size = new System.Drawing.Size(75, 23);
            this.btnTomcatRuntimeRemove.TabIndex = 1;
            this.btnTomcatRuntimeRemove.Text = "Remove";
            this.btnTomcatRuntimeRemove.UseVisualStyleBackColor = true;
            this.btnTomcatRuntimeRemove.Click += new System.EventHandler(this.btnTomcatRuntimeRemove_Click);
            // 
            // lvTomcatRuntime
            // 
            this.lvTomcatRuntime.HideSelection = false;
            this.lvTomcatRuntime.Location = new System.Drawing.Point(12, 12);
            this.lvTomcatRuntime.Name = "lvTomcatRuntime";
            this.lvTomcatRuntime.Size = new System.Drawing.Size(500, 300);
            this.lvTomcatRuntime.TabIndex = 2;
            this.lvTomcatRuntime.UseCompatibleStateImageBehavior = false;
            // 
            // TomcatRuntimeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 323);
            this.Controls.Add(this.lvTomcatRuntime);
            this.Controls.Add(this.btnTomcatRuntimeRemove);
            this.Controls.Add(this.btnTomcatRuntimeNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TomcatRuntimeManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tomcat Runtime";
            this.Load += new System.EventHandler(this.frmTomcatRuntime_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTomcatRuntimeNew;
        private System.Windows.Forms.Button btnTomcatRuntimeRemove;
        private System.Windows.Forms.ListView lvTomcatRuntime;
    }
}