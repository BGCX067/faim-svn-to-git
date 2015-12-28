using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FAim.Controls
{
    class CueTextBox : TextBox
    {

        //cue text var
        private string strCue;

        /// <summary>
        /// Gets or Sets the cue text
        /// </summary>
        public string CueText
        {
            get
            {
                return strCue;
            }
            set
            {
                //set the cue var, then update the gui
                strCue = value;
                SetCueText();
            }
        }
        
        /// <summary>
        /// Constructs a new CueTextBox
        /// </summary>
        public CueTextBox()
        {

            //default
            strCue = "";

        }

        private void SetCueText()
        {
            //tell windows to show the cue
            Win32Api.SendMessage(this.Handle, Win32Api.EM_SETCUEBANNER, IntPtr.Zero, strCue);
        }

    }
}
