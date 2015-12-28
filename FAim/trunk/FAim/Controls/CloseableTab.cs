using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAim.Controls
{
    public partial class CloseableTab : TabPage
    {

        //context menu for clicking on the button
        private ContextMenu ctmMenu = null;

        //IM stuff
        private String strRecipient;
        private AccCoreLib.IAccImSession imSession;

        //gui
        private InstantMessageControl imCont;


        /// <summary>
        /// Gets or Sets the recipient of this IM Session
        /// </summary>
        public String Recipient
        {
            get { return strRecipient; }
            set { strRecipient = value; }
        }

        /// <summary>
        /// Gets or Sets the IM Session associated with this conversation.
        /// </summary>
        public AccCoreLib.IAccImSession IM_Session
        {
            get { return imSession; }
            set { imSession = value; imCont.ImSession = value; }
        }

        /// <summary>
        /// Override the Text property, adding padding.
        /// </summary>
        public override string Text
        {
            get { return base.Text /*.PadRight(base.Text.Length + 50, ' '); }*/ + "                                                 "; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Gets or Sets the Context Menu for the Tab Page
        /// </summary>
        public ContextMenu Menu
        {
            get { return ctmMenu; }
            set { ctmMenu = value; }
        }


        /// <summary>
        /// Constructor for creating a new Closeable Tab.
        /// </summary>
        public CloseableTab()
        {
            InitializeComponent();
            CustomInit();
        }

        /// <summary>
        /// Custom Initialization
        /// </summary>
        private void CustomInit()
        {

            //create and dock in this
            imCont = new InstantMessageControl() { Dock = DockStyle.Fill };
            this.Controls.Add(imCont);

        }

        /// <summary>
        /// Designer Constructor. DO NOT USE.
        /// </summary>
        /// <param name="container"></param>
        public CloseableTab(System.ComponentModel.IContainer container)
		{

            //Designer Support
			container.Add(this);
			InitializeComponent();
            CustomInit();

		}


        public void ImReceived(String user, String text, AccCoreLib.IAccImSession imSess)
        {

            //add string to IM window
            imCont.AppendTextToReceive(text);

        }

        public void ChangeRate(AccCoreLib.AccRateState newState)
        {

            this.imCont.ChangeRateState((int)newState);

        }

    }
}
