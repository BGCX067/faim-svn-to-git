namespace FAim
{
    partial class BuddyInfo
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
            this.webInfo = new System.Windows.Forms.WebBrowser();
            this.btnClose = new FAim.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // webInfo
            // 
            this.webInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.webInfo.Location = new System.Drawing.Point(0, 0);
            this.webInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webInfo.Name = "webInfo";
            this.webInfo.Size = new System.Drawing.Size(550, 321);
            this.webInfo.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.AdminIcon = false;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(0, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Note = "";
            this.btnClose.Size = new System.Drawing.Size(550, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BuddyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 349);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.webInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BuddyInfo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "\'s Buddy Info";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webInfo;
        private FAim.Controls.CommandButton btnClose;
    }
}