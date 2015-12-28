using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FAim.Controls
{
    public partial class InstantMessageControl : UserControl
    {

        /* Change Progress Bar Back Color */
        //
        [DllImport("User32.Dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        public const int PBM_SETBARCOLOR = 0x409;
        //
        /*            End                 */

        //im session
        private AccCoreLib.IAccImSession imSess;


        /// <summary>
        /// Gets or Sets the ImSession.
        /// </summary>
        public AccCoreLib.IAccImSession ImSession
        {
            get { return imSess; }
            set { imSess = value; }
        }


        /// <summary>
        /// Constructs a InstantMessageControl
        /// </summary>
        public InstantMessageControl()
        {
            InitializeComponent();
            CustomInit();
        }

        /// <summary>
        /// Custom Initialization
        /// </summary>
        private void CustomInit()
        {

            InitFonts();
            InitSizes();

        }

        /// <summary>
        /// Initialize the Font List
        /// </summary>
        private void InitFonts()
        {

            //get all fonts
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();

            //iterate each font, adding it to the combo box
            foreach (FontFamily f in fonts.Families)
                this.cmbFonts.Items.Add(f.Name);

        }

        /// <summary>
        /// Initialize the Font Size list
        /// </summary>
        private void InitSizes()
        {

            //add sizes to the combo box
            for (int i = 2; i < 50; i += 2)
                this.cmbFontSize.Items.Add(i);

        }


        #region Font Changes

        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the font
            this.rtbSend.SelectionFont = new Font(this.cmbFonts.SelectedItem.ToString(), this.rtbSend.SelectionFont.Size, this.rtbSend.SelectionFont.Style);
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the size
            this.rtbSend.SelectionFont = new Font(this.rtbSend.SelectionFont.FontFamily, float.Parse(this.cmbFontSize.SelectedItem.ToString()), this.rtbSend.SelectionFont.Style);
        }

        private void btnBold_Click(object sender, EventArgs e)
        {

            //original font
            Font fntSelect = this.rtbSend.SelectionFont;

            //change font
            this.rtbSend.SelectionFont = new Font(fntSelect, fntSelect.Style ^ FontStyle.Bold);

        }

        private void btnItalic_Click(object sender, EventArgs e)
        {

            //original font
            Font fntSelect = this.rtbSend.SelectionFont;

            //change font
            this.rtbSend.SelectionFont = new Font(fntSelect, fntSelect.Style ^ FontStyle.Italic);

        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {

            //original font
            Font fntSelect = this.rtbSend.SelectionFont;

            //change font
            this.rtbSend.SelectionFont = new Font(fntSelect, fntSelect.Style ^ FontStyle.Underline);

        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {

            //font color dialog box
            ColorDialog clrDiag = new ColorDialog();

            //default colors
            Color clrNoSelect = this.rtbSend.ForeColor;
            Color clrSelect = this.rtbSend.SelectionColor;

            //set defaults
            clrDiag.AllowFullOpen = true;
            clrDiag.AnyColor = true;
            clrDiag.FullOpen = false;
            
            //check for selection
            if (this.rtbSend.SelectedText == String.Empty)
            {

                //set the default
                clrDiag.Color = clrNoSelect;

                //set the color
                if ((clrDiag.ShowDialog() == DialogResult.OK) && (clrDiag.Color != null))
                    this.rtbSend.ForeColor = clrDiag.Color;

            }
            else
            {

                //set the default
                clrDiag.Color = clrSelect;

                //set the color
                if ((clrDiag.ShowDialog() == DialogResult.OK) && (clrDiag.Color != null))
                    this.rtbSend.SelectionColor = clrDiag.Color;

            }

        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {

            //font color dialog box
            ColorDialog clrDiag = new ColorDialog();

            //default colors
            Color clrNoSelect = this.rtbSend.BackColor;
            Color clrSelect = this.rtbSend.SelectionBackColor;

            //set defaults
            clrDiag.AllowFullOpen = true;
            clrDiag.AnyColor = true;
            clrDiag.FullOpen = false;

            //check for selection
            if (this.rtbSend.SelectedText == String.Empty)
            {

                //set the default
                clrDiag.Color = clrNoSelect;

                //set the color
                if ((clrDiag.ShowDialog() == DialogResult.OK) && (clrDiag.Color != null))
                    this.rtbSend.BackColor = clrDiag.Color;

            }
            else
            {

                //set the default
                clrDiag.Color = clrSelect;

                //set the color
                if ((clrDiag.ShowDialog() == DialogResult.OK) && (clrDiag.Color != null))
                    this.rtbSend.SelectionBackColor = clrDiag.Color;

            }

        }

        #endregion

        private void SendIm()
        {

            //if we arent limited...
            if (this.progRate.Value != (int)AccCoreLib.AccRateState.AccRateState_Limit)
            {

                //send the im
                Logic.Actions.SendIm(this.rtbSend, imSess);

                //show in UI
                AppendTextToReceive("<font color=\"blue\">" + Logic.Actions.UserName() + " (" + DateTime.Now.ToShortTimeString() 
                                     + "):</font> " + Logic.Actions.ConvertToHtml(this.rtbSend).Replace("\r\n", "").Replace("<br></BODY>", "</body>"));

                //clear the text
                this.rtbSend.Text = "";

            }
                //if we are limited, say so
            else
                AppendTextToReceive("<font color=\"red\">SYSTEM MESSAGE (" + DateTime.Now.ToShortTimeString() + "): RATE LIMITED. INSTANT MESSAGES NOT SENT. PLEASE WAIT FOR LIMIT TO DECREASE</font>");

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //send the IM
            SendIm();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {

            //request info
            

        }

        public void AppendTextToReceive(String NewText)
        {

            //append to webReceive
            this.webReceive.DocumentText += NewText + "<br />";

        }

        public void ChangeRateState(int RateNumber)
        {

            //set new rate
            this.progRate.Value = 3 - RateNumber;

            //vars for color changing
            int tot = -1;
            int hwnd = -1;

            switch (this.progRate.Value)
            {
                case 0:
                    //set bar color to green
                    tot = Convert.ToInt32(ColorTranslator.ToOle(Color.Green).ToString());
                    hwnd = this.progRate.ProgressBar.Handle.ToInt32();
                    SendMessage(hwnd, PBM_SETBARCOLOR, 0, tot);
                    break;

                case 1:
                    //set bar color to green
                    tot = Convert.ToInt32(ColorTranslator.ToOle(Color.Green).ToString());
                    hwnd = this.progRate.ProgressBar.Handle.ToInt32();
                    SendMessage(hwnd, PBM_SETBARCOLOR, 0, tot);
                    break;

                case 2:
                    //set bar color to orange
                    tot = Convert.ToInt32(ColorTranslator.ToOle(Color.Orange).ToString());
                    hwnd = this.progRate.ProgressBar.Handle.ToInt32();
                    SendMessage(hwnd, PBM_SETBARCOLOR, 0, tot);
                    break;

                case 3:
                    //set bar color to red
                    tot = Convert.ToInt32(ColorTranslator.ToOle(Color.Red).ToString());
                    hwnd = this.progRate.ProgressBar.Handle.ToInt32();
                    SendMessage(hwnd, PBM_SETBARCOLOR, 0, tot);
                    break;

            }

        }

        private void rtbSend_KeyDown(object sender, KeyEventArgs e)
        {

            //send IM if the user pushes enter
            if ((e.KeyCode == Keys.Enter) && (e.Control == false))
            {
                //send the im
                SendIm();

                //surpress key
                e.SuppressKeyPress = true;
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Control == true))
            {
                //add newline
                this.rtbSend.SelectedText += "\r\n";

                //surpress keypress
                e.SuppressKeyPress = true;
            }

        }

        

    }
}
