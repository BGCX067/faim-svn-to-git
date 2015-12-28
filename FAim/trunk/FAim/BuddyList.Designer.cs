namespace FAim
{
    partial class BuddyList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuddyList));
            this.tlsCommonCommands = new System.Windows.Forms.ToolStrip();
            this.btnSendIm = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddBuddy = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveBuddy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.imlBuddyList = new System.Windows.Forms.ImageList(this.components);
            this.trvBuddyList = new FAim.Controls.VistaTreeView();
            this.tlsCommonCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsCommonCommands
            // 
            this.tlsCommonCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsCommonCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendIm,
            this.btnSend,
            this.btnGetInfo,
            this.toolStripSeparator1,
            this.btnAddBuddy,
            this.btnRemoveBuddy,
            this.toolStripSeparator2,
            this.btnAddGroup,
            this.btnRemoveGroup,
            this.toolStripSeparator3,
            this.btnSettings});
            this.tlsCommonCommands.Location = new System.Drawing.Point(0, 628);
            this.tlsCommonCommands.Name = "tlsCommonCommands";
            this.tlsCommonCommands.Size = new System.Drawing.Size(218, 29);
            this.tlsCommonCommands.TabIndex = 1;
            this.tlsCommonCommands.Text = "toolStrip1";
            // 
            // btnSendIm
            // 
            this.btnSendIm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSendIm.Image = global::FAim.Properties.Resources.send_small;
            this.btnSendIm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendIm.Name = "btnSendIm";
            this.btnSendIm.Size = new System.Drawing.Size(23, 26);
            this.btnSendIm.Text = "Send IM";
            this.btnSendIm.Click += new System.EventHandler(this.btnSendIm_Click);
            // 
            // btnSend
            // 
            this.btnSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendFile,
            this.mnuSendDirectory});
            this.btnSend.Image = global::FAim.Properties.Resources.up_small;
            this.btnSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(32, 26);
            this.btnSend.Text = "Send...";
            // 
            // mnuSendFile
            // 
            this.mnuSendFile.Image = global::FAim.Properties.Resources.doc_small;
            this.mnuSendFile.Name = "mnuSendFile";
            this.mnuSendFile.Size = new System.Drawing.Size(151, 22);
            this.mnuSendFile.Text = "Send File";
            this.mnuSendFile.ToolTipText = "Send File";
            // 
            // mnuSendDirectory
            // 
            this.mnuSendDirectory.Image = global::FAim.Properties.Resources.folderOpen_small;
            this.mnuSendDirectory.Name = "mnuSendDirectory";
            this.mnuSendDirectory.Size = new System.Drawing.Size(151, 22);
            this.mnuSendDirectory.Text = "Send Directory";
            this.mnuSendDirectory.ToolTipText = "Send Directory";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGetInfo.Image = global::FAim.Properties.Resources.info_small;
            this.btnGetInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGetInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(26, 26);
            this.btnGetInfo.Text = "Get Info";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnAddBuddy
            // 
            this.btnAddBuddy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddBuddy.Image = global::FAim.Properties.Resources.add_small;
            this.btnAddBuddy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddBuddy.Name = "btnAddBuddy";
            this.btnAddBuddy.Size = new System.Drawing.Size(23, 26);
            this.btnAddBuddy.Text = "Add Buddy";
            // 
            // btnRemoveBuddy
            // 
            this.btnRemoveBuddy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveBuddy.Image = global::FAim.Properties.Resources.delete_small;
            this.btnRemoveBuddy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveBuddy.Name = "btnRemoveBuddy";
            this.btnRemoveBuddy.Size = new System.Drawing.Size(23, 26);
            this.btnRemoveBuddy.Text = "Remove Buddy";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddGroup.Image = global::FAim.Properties.Resources.add2_small;
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(23, 26);
            this.btnAddGroup.Text = "Add Group";
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveGroup.Image = global::FAim.Properties.Resources.delete2_small;
            this.btnRemoveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(23, 26);
            this.btnRemoveGroup.Text = "Remove Group";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = global::FAim.Properties.Resources.settings_small;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 20);
            this.btnSettings.Text = "Settings";
            // 
            // imlBuddyList
            // 
            this.imlBuddyList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBuddyList.ImageStream")));
            this.imlBuddyList.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBuddyList.Images.SetKeyName(0, "offline");
            this.imlBuddyList.Images.SetKeyName(1, "online");
            this.imlBuddyList.Images.SetKeyName(2, "away");
            this.imlBuddyList.Images.SetKeyName(3, "idle");
            this.imlBuddyList.Images.SetKeyName(4, "mobile");
            this.imlBuddyList.Images.SetKeyName(5, "blank");
            // 
            // trvBuddyList
            // 
            this.trvBuddyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvBuddyList.HotTracking = true;
            this.trvBuddyList.ImageIndex = 1;
            this.trvBuddyList.ImageList = this.imlBuddyList;
            this.trvBuddyList.Location = new System.Drawing.Point(12, 12);
            this.trvBuddyList.Name = "trvBuddyList";
            this.trvBuddyList.SelectedImageIndex = 1;
            this.trvBuddyList.ShowLines = false;
            this.trvBuddyList.Size = new System.Drawing.Size(194, 603);
            this.trvBuddyList.TabIndex = 0;
            this.trvBuddyList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trvBuddyList_MouseDoubleClick);
            this.trvBuddyList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvBuddyList_KeyDown);
            // 
            // BuddyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 657);
            this.Controls.Add(this.tlsCommonCommands);
            this.Controls.Add(this.trvBuddyList);
            this.MaximizeBox = false;
            this.Name = "BuddyList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "\'s Buddy List";
            this.tlsCommonCommands.ResumeLayout(false);
            this.tlsCommonCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FAim.Controls.VistaTreeView trvBuddyList;
        private System.Windows.Forms.ToolStrip tlsCommonCommands;
        private System.Windows.Forms.ToolStripButton btnSendIm;
        private System.Windows.Forms.ToolStripSplitButton btnSend;
        private System.Windows.Forms.ToolStripMenuItem mnuSendFile;
        private System.Windows.Forms.ToolStripButton btnGetInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddBuddy;
        private System.Windows.Forms.ToolStripButton btnRemoveBuddy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAddGroup;
        private System.Windows.Forms.ToolStripButton btnRemoveGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuSendDirectory;
        private System.Windows.Forms.ImageList imlBuddyList;
    }
}