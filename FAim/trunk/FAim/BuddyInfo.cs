using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAim
{
    public partial class BuddyInfo : Form
    {
        public BuddyInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInfo(String user, String text)
        {

            //set info
            this.Text = user + "'s Buddy Info";
            this.webInfo.DocumentText = text;

        }

    }
}
