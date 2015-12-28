using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AccCoreLib;
using FAim.Controls;

namespace FAim
{
    public partial class InstantMessageWindow : Form
    {

        //hash of tabs, for quick retrieval.
        private Dictionary<String, CloseableTab> dicTabs;

        public InstantMessageWindow()
        {
            InitializeComponent();
            CustomInit();
        }

        private void CustomInit()
        {

            //init vars
            dicTabs = new Dictionary<String, CloseableTab>();

            //on close event
            this.tbctrlMain.OnClose += new CloseableTabControl.delOnHeaderClose(tbctrlMain_OnClose);

        }

        void tbctrlMain_OnClose(TabPage tab)
        {
            this.tbctrlMain.TabPages.Remove(tab);
        }


        public void AddNewIM(String usr, IAccImSession imSes)
        {

            //internal method
            //InternalCreateTab(usr, imSes);
            GetOrCreateTab(usr, imSes);

        }

        private CloseableTab ShowTab(String usr)
        {
            
            //add cached tab to the control
            if (this.tbctrlMain.TabPages.Contains(dicTabs[usr]) == false)
                this.tbctrlMain.TabPages.Add(dicTabs[usr]);

            //return the tab
            return dicTabs[usr];

        }

        private CloseableTab InternalCreateTab(String user, IAccImSession imSes)
        {

            //create a new tab page
            CloseableTab tab = new CloseableTab();

            //add tab to hash and to tab control
            tab.Text = user;
            tab.IM_Session = imSes;
            if (dicTabs.ContainsKey(user) == false)
                dicTabs.Add(user, tab);
            this.tbctrlMain.TabPages.Add(tab);

            //return the tab
            return tab;

        }

        private CloseableTab GetOrCreateTab(String user, IAccImSession imSess)
        {

            //if the user already talked to this person but closed the window, bring it back up. if not, create a new convo.
            if (dicTabs.ContainsKey(user))
                return ShowTab(user);
            else
               return InternalCreateTab(user, imSess);

        }

        public void InstantMessageReceived(String user, String Text, IAccImSession imSess)
        {

            //get the tab and pass the im to it
            GetOrCreateTab(user, imSess).ImReceived(user, Text, imSess);

            //check if wer visible or not
            if (this.Visible == false)
                this.Show();

        }

        internal void RequestInfo(CloseableTab tab)
        {

            //request the info for the tab
            //Logic.Actions.GetBuddyInfo(dicTabs.Values[tab]

        }

        public void ChangeRateState(IAccImSession imSess, AccRateState newRate)
        {

            //find the tab, change the state
            foreach (CloseableTab tab in dicTabs.Values)
                if (tab.IM_Session == imSess)
                    tab.ChangeRate(newRate);

        }

        private void InstantMessageWindow_KeyDown(object sender, KeyEventArgs e)
        {

            //close open tab when escape key is pressed
            if (e.KeyCode == Keys.Escape)
                CloseTab(this.tbctrlMain.SelectedTab);

            //check if we should hide the window
            if (this.tbctrlMain.TabPages.Count == 0)
                this.Hide();

        }

        private void CloseTab(TabPage tab)
        {
            //remove the tab
            this.tbctrlMain.TabPages.Remove(tab);
        }

        private void InstantMessageWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            //check to see if wer exiting due to the x button or the app closing
            if ((e.CloseReason == CloseReason.UserClosing) || (e.CloseReason == CloseReason.TaskManagerClosing))
            {
                //hide the form if the user tries to close it. this preserves the object instance
                this.Hide();
                e.Cancel = true;
            }

        }

        

    }
}
