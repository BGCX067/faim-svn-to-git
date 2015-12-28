using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FAim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            //enable visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //make the buddy list form the main form (so we can close the login form and not have the app close)
            /*BuddyList bl = new BuddyList();
            Form1 frm = new Form1();

            //set the Form1 BuddyList var for showing later
            frm.BuddyListForm = bl;

            //run the buddy list
            Application.Run(bl);*/
            Application.Run(new Form1());

        }
    }
}
