using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAim
{
    public partial class Form1 : Form
    {

        //static form variable for later use
        private static Form1 frmOpen;

        /// <summary>
        /// Gets the Open Instance of the Login Form.
        /// </summary>
        public static Form1 CurrentForm
        {
            get { return frmOpen; }
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            CustomInit();
        }

        /// <summary>
        /// Custom initialization done here.
        /// </summary>
        private void CustomInit()
        {

            //assign this to the static var
            frmOpen = this;

            //listen for the signon events
            Logic.EventHandler.InvalidPassword += new Logic.EventHandler.delInvalidPassword(EventHandler_InvalidPassword);
            Logic.EventHandler.InvalidScreenName += new Logic.EventHandler.delInvalidScreenName(EventHandler_InvalidScreenName);
            Logic.EventHandler.SuccessfulLogin += new Logic.EventHandler.delSuccessfulLogin(EventHandler_SuccessfulLogin);
            Logic.EventHandler.UnknownSignonError += new Logic.EventHandler.delUnknownSignonError(EventHandler_UnknownSignonError);

        }


        private void EventHandler_UnknownSignonError()
        {
            
            //set the error
            this.errError.SetIconAlignment(this.btnLogin, ErrorIconAlignment.MiddleRight);
            this.errError.SetError(this.btnLogin, "Unknown Sign On error has occured. Please try again later.");

            //allow them to try again
            this.btnLogin.Enabled = true;

        }

        private void EventHandler_SuccessfulLogin()
        {

            //create new buddy list
            BuddyList bl = new BuddyList();

            //show it
            bl.Show();
            bl.Text = this.txtSn.Text + "'s Buddy List";

            //hide me
            this.Hide();

            //allow them to try again if the form becomes visible
            this.btnLogin.Enabled = true;

        }

        private void EventHandler_InvalidScreenName()
        {

            //set the error
            this.errError.SetIconAlignment(this.txtSn, ErrorIconAlignment.MiddleRight);
            this.errError.SetError(this.txtSn, "Invalid or Banned Screen Name.");

            //allow them to try again
            this.btnLogin.Enabled = true;

        }

        private void EventHandler_InvalidPassword()
        {

            //set the error
            this.errError.SetIconAlignment(this.txtPassword, ErrorIconAlignment.MiddleRight);
            this.errError.SetError(this.txtPassword, "Invalid Password.");

            //allow them to try again
            this.btnLogin.Enabled = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //Call sign on method
            SignOn();

        }

        private void SignOn()
        {

            //don't let them push the button again until we get a response
            this.btnLogin.Enabled = false;

            //clear all errors
            this.errError.Clear();

            //local check for errors
            if (this.txtPassword.Text == String.Empty)
                EventHandler_InvalidPassword();
            if (this.txtSn.Text == String.Empty)
                EventHandler_InvalidScreenName();

            //attempt to login
            Logic.Actions.SignOn(this.txtSn.Text, this.txtPassword.Text);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            //if they push enter, try to sign in
            if (e.KeyCode == Keys.Enter)
                SignOn();

        }

    }
}
