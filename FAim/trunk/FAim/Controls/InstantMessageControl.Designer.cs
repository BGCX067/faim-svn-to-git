namespace FAim.Controls
{
    partial class InstantMessageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webReceive = new System.Windows.Forms.WebBrowser();
            this.spltContainer = new System.Windows.Forms.SplitContainer();
            this.spltSend = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmbFonts = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.btnFontColor = new System.Windows.Forms.ToolStripButton();
            this.btnBackColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmiconsMain = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.progRate = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.lblSpacer = new System.Windows.Forms.ToolStripLabel();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.spltContainer.Panel1.SuspendLayout();
            this.spltContainer.Panel2.SuspendLayout();
            this.spltContainer.SuspendLayout();
            this.spltSend.Panel1.SuspendLayout();
            this.spltSend.Panel2.SuspendLayout();
            this.spltSend.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webReceive
            // 
            this.webReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webReceive.Location = new System.Drawing.Point(0, 0);
            this.webReceive.MinimumSize = new System.Drawing.Size(20, 20);
            this.webReceive.Name = "webReceive";
            this.webReceive.Size = new System.Drawing.Size(579, 306);
            this.webReceive.TabIndex = 0;
            // 
            // spltContainer
            // 
            this.spltContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltContainer.Location = new System.Drawing.Point(0, 0);
            this.spltContainer.Name = "spltContainer";
            this.spltContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltContainer.Panel1
            // 
            this.spltContainer.Panel1.Controls.Add(this.webReceive);
            // 
            // spltContainer.Panel2
            // 
            this.spltContainer.Panel2.Controls.Add(this.spltSend);
            this.spltContainer.Size = new System.Drawing.Size(579, 471);
            this.spltContainer.SplitterDistance = 306;
            this.spltContainer.TabIndex = 1;
            // 
            // spltSend
            // 
            this.spltSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltSend.Location = new System.Drawing.Point(0, 0);
            this.spltSend.Name = "spltSend";
            this.spltSend.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltSend.Panel1
            // 
            this.spltSend.Panel1.Controls.Add(this.toolStrip1);
            // 
            // spltSend.Panel2
            // 
            this.spltSend.Panel2.Controls.Add(this.rtbSend);
            this.spltSend.Size = new System.Drawing.Size(579, 161);
            this.spltSend.SplitterDistance = 25;
            this.spltSend.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbFonts,
            this.cmbFontSize,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.btnFontColor,
            this.btnBackColor,
            this.toolStripSeparator1,
            this.btnEmiconsMain,
            this.toolStripSeparator2,
            this.progRate,
            this.toolStripSeparator3,
            this.btnSend,
            this.lblSpacer,
            this.btnInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbFonts
            // 
            this.cmbFonts.MaxDropDownItems = 100;
            this.cmbFonts.Name = "cmbFonts";
            this.cmbFonts.Size = new System.Drawing.Size(121, 35);
            this.cmbFonts.Text = "Times New Roman";
            this.cmbFonts.SelectedIndexChanged += new System.EventHandler(this.cmbFonts_SelectedIndexChanged);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.MaxDropDownItems = 100;
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(75, 25);
            this.cmbFontSize.Text = "12";
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // btnBold
            // 
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = global::FAim.Properties.Resources.font_bold;
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "Bold Font";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = global::FAim.Properties.Resources.font_italic;
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Text = "Italic Font";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.CheckOnClick = true;
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = global::FAim.Properties.Resources.font_underline;
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Text = "Underline Font";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnFontColor
            // 
            this.btnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFontColor.Image = global::FAim.Properties.Resources.font_color;
            this.btnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(23, 22);
            this.btnFontColor.Text = "Font Foreground Color";
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBackColor.Image = global::FAim.Properties.Resources.back_color;
            this.btnBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(23, 22);
            this.btnBackColor.Text = "Font Background Color";
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btnEmiconsMain
            // 
            this.btnEmiconsMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEmiconsMain.Image = global::FAim.Properties.Resources.emicon;
            this.btnEmiconsMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmiconsMain.Name = "btnEmiconsMain";
            this.btnEmiconsMain.Size = new System.Drawing.Size(32, 22);
            this.btnEmiconsMain.Text = "Emicons";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // progRate
            // 
            this.progRate.Maximum = 3;
            this.progRate.Name = "progRate";
            this.progRate.Size = new System.Drawing.Size(100, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // btnSend
            // 
            this.btnSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSend.Image = global::FAim.Properties.Resources.send_small;
            this.btnSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(23, 22);
            this.btnSend.Text = "Send IM";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSpacer
            // 
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(31, 32);
            this.lblSpacer.Text = "        ";
            // 
            // btnInfo
            // 
            this.btnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInfo.Image = global::FAim.Properties.Resources.info_small;
            this.btnInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(26, 22);
            this.btnInfo.Text = "Get Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // rtbSend
            // 
            this.rtbSend.AcceptsTab = true;
            this.rtbSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSend.Location = new System.Drawing.Point(0, 0);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(579, 132);
            this.rtbSend.TabIndex = 0;
            this.rtbSend.Text = "";
            this.rtbSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbSend_KeyDown);
            // 
            // InstantMessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltContainer);
            this.Name = "InstantMessageControl";
            this.Size = new System.Drawing.Size(579, 471);
            this.spltContainer.Panel1.ResumeLayout(false);
            this.spltContainer.Panel2.ResumeLayout(false);
            this.spltContainer.ResumeLayout(false);
            this.spltSend.Panel1.ResumeLayout(false);
            this.spltSend.Panel1.PerformLayout();
            this.spltSend.Panel2.ResumeLayout(false);
            this.spltSend.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webReceive;
        private System.Windows.Forms.SplitContainer spltContainer;
        private System.Windows.Forms.SplitContainer spltSend;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbFonts;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnFontColor;
        private System.Windows.Forms.ToolStripButton btnBackColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnEmiconsMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripProgressBar progRate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSend;
        private System.Windows.Forms.ToolStripLabel lblSpacer;
        private System.Windows.Forms.ToolStripButton btnInfo;
    }
}
