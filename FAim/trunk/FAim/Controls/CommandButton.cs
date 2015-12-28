using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAim.Controls
{
    public partial class CommandButton : Button
    {

        //init vars
        private String strNote = "";
        private Boolean bAdminIcon = false;


        /// <summary>
        /// Gets or Sets if this Command Button should have the Shield Icon
        /// </summary>
        public Boolean AdminIcon
        {
            get { return bAdminIcon; }
            set 
            {
                //set to use shield
                bAdminIcon = value;
                Win32Api.SendMessage(this.Handle, Win32Api.BCM_SETSHIELD, IntPtr.Zero, new IntPtr(value ? 1 : 0));
            }
        }

        /// <summary>
        /// Gets or Sets the Note of this command button.
        /// </summary>
        public String Note
        {
            get { return strNote; }
            set 
            {
                //set the note
                strNote = value;
                Win32Api.SendMessage(this.Handle, Win32Api.BCM_SETNOTE, IntPtr.Zero, value);
            }
        }


        public CommandButton()
        {
            InitializeComponent();
            CustomInit();
        }

        private void CustomInit()
        {
            //set to flat
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }


        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {

                System.Windows.Forms.CreateParams cParams = base.CreateParams;

                //Set the button to use Commandlink styles
                cParams.Style |= Win32Api.BS_COMMANDLINK;
                return cParams;

            }
        }
    
    
    }
}
