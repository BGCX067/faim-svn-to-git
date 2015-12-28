namespace FAim
{
    partial class InstantMessageWindow
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
            this.tbctrlMain = new FAim.Controls.CloseableTabControl();
            this.SuspendLayout();
            // 
            // tbctrlMain
            // 
            this.tbctrlMain.ConfirmOnClose = false;
            this.tbctrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbctrlMain.ItemSize = new System.Drawing.Size(230, 24);
            this.tbctrlMain.Location = new System.Drawing.Point(0, 0);
            this.tbctrlMain.Name = "tbctrlMain";
            this.tbctrlMain.SelectedIndex = 0;
            this.tbctrlMain.Size = new System.Drawing.Size(627, 543);
            this.tbctrlMain.TabIndex = 0;
            this.tbctrlMain.TabStop = false;
            // 
            // InstantMessageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 543);
            this.Controls.Add(this.tbctrlMain);
            this.KeyPreview = true;
            this.Name = "InstantMessageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "\'s Instant Messages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstantMessageWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InstantMessageWindow_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private FAim.Controls.CloseableTabControl tbctrlMain;

    }
}