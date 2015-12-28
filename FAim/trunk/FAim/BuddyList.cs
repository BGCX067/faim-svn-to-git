using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAim
{
    public partial class BuddyList : Form
    {

        //idle color (TREAT AS CONSTANT, Color types cant be declared constant)
        private Color IDLE_COLOR = Color.LightGray;

        //im window 
        private InstantMessageWindow frmImWindow;


        /// <summary>
        /// Image index states
        /// </summary>
        private enum ImageStates : int
        {
            Offline = 0,
            Online = 1,
            Away = 2,
            Idle = 3,
            Mobile = 4,
            Blank = 5
        }

        public BuddyList()
        {
            InitializeComponent();
            CustomInit();
        }

        public void CustomInit()
        {

            //create IM window
            frmImWindow = new InstantMessageWindow();
            frmImWindow.Text = Logic.Actions.UserName() + "'s Instant Message Window";

            //subcribe to events
            Logic.EventHandler.GroupsLoaded += new Logic.EventHandler.delGroupsLoaded(EventHandler_GroupsLoaded);
            Logic.EventHandler.NamesLoaded += new Logic.EventHandler.delNamesLoaded(EventHandler_NamesLoaded);
            Logic.EventHandler.BuddySignedOffline += new Logic.EventHandler.delBuddySignedOffline(EventHandler_BuddySignedOffline);
            Logic.EventHandler.BuddySignedOnline += new Logic.EventHandler.delBuddySignedOnline(EventHandler_BuddySignedOnline);
            Logic.EventHandler.BuddyWentAway += new Logic.EventHandler.delBuddyWentAway(EventHandler_BuddyWentAway);
            Logic.EventHandler.BuddyWentIdle += new Logic.EventHandler.delBuddyWentIdle(EventHandler_BuddyWentIdle);
            Logic.EventHandler.InstantMessageReceived += new Logic.EventHandler.delInstantMessageReceived(EventHandler_InstantMessageReceived);
            Logic.EventHandler.RateStateChanged += new Logic.EventHandler.delRateStateChanged(EventHandler_RateStateChanged);

        }


        private void EventHandler_RateStateChanged(AccCoreLib.IAccImSession imSess, AccCoreLib.AccRateState NewState)
        {
            //pass to IM window
            frmImWindow.ChangeRateState(imSess, NewState);
        }

        private void EventHandler_InstantMessageReceived(string user, string text, AccCoreLib.IAccImSession imSess)
        {
            //pass to IM window
            frmImWindow.InstantMessageReceived(user, text, imSess);
        }

        private void SortBuddies()
        {
            
            //sort the buddies in each group (skipping the Offline node)
            for (int i = 0; i < this.trvBuddyList.Nodes.Count - 1; i++)
            {

                //array for positions
                TreeNode[] arr = new TreeNode[Logic.Actions.NumberOfBuddiesInGroup(this.trvBuddyList.Nodes[i].Name)];

                //put them in order
                for (int j = 0; j < this.trvBuddyList.Nodes[i].Nodes.Count; j++)
                    arr[Logic.Actions.BuddyPosition(this.trvBuddyList.Nodes[i].Nodes[j].Name, this.trvBuddyList.Nodes[i].Name)] = this.trvBuddyList.Nodes[i].Nodes[j];

                //clear Tree Nodes in Group node
                this.trvBuddyList.Nodes[i].Nodes.Clear();

                //readd nodes
                foreach (TreeNode tn in arr)
                    if (tn != null)
                        this.trvBuddyList.Nodes[i].Nodes.Add(tn);

            }

        }

        private void EventHandler_NamesLoaded(List<string> Names)
        {
            
            //add users to Offline group
            foreach (String user in Names)
            {

                //create Tree Node
                TreeNode node = new TreeNode() { Name = user, Text = user, ImageIndex = 1, SelectedImageIndex = 1 };

                //add to Offline node
                this.trvBuddyList.Nodes["Offline"].Nodes.Add(node);

            }

        }

        private void EventHandler_BuddyWentIdle(string Name, string[] Groups)
        {

            //make the image index the idle image
            foreach (String group in Groups)
            {
                this.trvBuddyList.Nodes[group].Nodes[Name].SelectedImageIndex = (int)ImageStates.Idle;
                this.trvBuddyList.Nodes[group].Nodes[Name].ImageIndex = (int)ImageStates.Idle;
                this.trvBuddyList.Nodes[group].Nodes[Name].BackColor = IDLE_COLOR;
            }

        }

        private void EventHandler_BuddyWentAway(string Name, string[] Groups)
        {

            //make the image index the away image
            foreach (String group in Groups)
            {
                this.trvBuddyList.Nodes[group].Nodes[Name].SelectedImageIndex = (int)ImageStates.Away;
                this.trvBuddyList.Nodes[group].Nodes[Name].ImageIndex = (int)ImageStates.Away;
            }

            //check for idle
            Logic.Actions.CheckBuddyIdle(Name);

        }

        private void EventHandler_BuddySignedOnline(string Name, string[] Groups)
        {

            //make a tree node and set the buddy to online
            foreach (String group in Groups)
            {

                //check if node exists first (user coming from Away to Online)
                if (this.trvBuddyList.Nodes[group].Nodes.ContainsKey(Name))
                {

                    //get node
                    TreeNode tn = this.trvBuddyList.Nodes[group].Nodes[Name];

                    //set default
                    tn.BackColor = this.trvBuddyList.BackColor;
                    tn.SelectedImageIndex = (int)ImageStates.Online;
                    tn.ImageIndex = (int)ImageStates.Online;

                }
                else
                {

                    //create node
                    TreeNode tn = new TreeNode() { Name = Name, Text = Name, SelectedImageIndex = (int)ImageStates.Online, ImageIndex = (int)ImageStates.Online };

                    //add to group
                    this.trvBuddyList.Nodes[group].Nodes.Insert(Logic.Actions.BuddyPosition(Name, group), tn);

                }

            }

            //check for idle
            Logic.Actions.CheckBuddyIdle(Name);

            //sort buddies
            SortBuddies();

        }

        private void EventHandler_BuddySignedOffline(string Name, string[] Groups)
        {

            //make a tree node and set the buddy to offline (aka remove them from group, add to offline group)
            foreach (String group in Groups)
                //remove from group
                this.trvBuddyList.Nodes[group].Nodes.RemoveByKey(Name);

            //create node
            TreeNode tn = new TreeNode() { Name = Name, Text = Name, SelectedImageIndex = (int)ImageStates.Online, ImageIndex = (int)ImageStates.Offline };

            //add it to the Offline
            this.trvBuddyList.Nodes["Offline"].Nodes.Add(tn);

            //sort Buddies
            SortBuddies();

        }

        private void EventHandler_GroupsLoaded(List<KeyValuePair<int, string>> Groups)
        {

            //array for sorting groups
            TreeNode[] arr = new TreeNode[Groups.Count];
            
            //iterate the groups, adding them to the treeview
            foreach (KeyValuePair<int, string> pair in Groups)
            {

                //create tree node
                TreeNode tn = new TreeNode() { Name = pair.Value, Text = pair.Value, SelectedImageIndex = (int)ImageStates.Blank, ImageIndex = (int)ImageStates.Blank };

                //add to array in order
                arr[pair.Key] = tn;

            }

            //add to tree in right order
            foreach (TreeNode n in arr)
                this.trvBuddyList.Nodes.Add(n);

        }

        private void trvBuddyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //get node
            TreeNode tn = this.trvBuddyList.GetNodeAt(e.Location);

            //check that this is a user, not nothing or a group name
            if ((tn != null) && (tn.Parent != null))
                CreateIM(tn);
            

        }

        private void CreateIM(TreeNode tn)
        {

            //add the new IM
            frmImWindow.AddNewIM(tn.Name, Logic.Actions.CreateOrGetSession(tn.Name, AccCoreLib.AccImSessionType.AccImSessionType_Im));
            frmImWindow.Show();

        }

        private void trvBuddyList_KeyDown(object sender, KeyEventArgs e)
        {

            //get the selected tree node
            TreeNode tn = this.trvBuddyList.SelectedNode;

            //check that the node isnt null
            if (tn == null)
                return;

            //check if its a user or group
            if (tn.Parent == null)
                return;
            else  //parent isnt null so its a user, start an IM
                CreateIM(tn);

        }

        private void btnSendIm_Click(object sender, EventArgs e)
        {

            //get tree node
            TreeNode tn = this.trvBuddyList.SelectedNode;

            //make sure its a user
            if ((tn != null) && (tn.Parent != null))
                CreateIM(tn);

        }


    }
}
