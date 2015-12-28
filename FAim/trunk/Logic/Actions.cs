using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using AccCoreLib;

namespace Logic
{
    public static class Actions
    {

        //create a queue for combination of requests
        private static Queue<int> queueComboRequests;


        //declare statement for create of session object
        [DllImport("acccore.dll", EntryPoint = "#111")]
        public static extern void AccCreateSession([MarshalAs(UnmanagedType.LPStruct)] Guid Name, [MarshalAs(UnmanagedType.IDispatch)] ref Object ses);


        //list of requests
        //private static List<int> lstRequests;

        //session var
        private static AccSession accSess;

        /// <summary>
        /// Gets or Sets the Request Queue.
        /// </summary>
        public static Queue<int> QueueOfRequests
        {
            get { return queueComboRequests; }
            set { queueComboRequests = value; }
        }

        /// <summary>
        /// Returns the SN of the signed in user.
        /// </summary>
        /// <returns></returns>
        public static string UserName()
        {
            return Logic.EventHandler.accSess.Identity;
        }

        /// <summary>
        /// Static Constructor
        /// </summary>
        static Actions()
        {

            //tmp object for creation (Bug: AccCreateSession cant take the session object itself as a parameter)
            Object tmp = new Object();

            //qeueue of requests
            queueComboRequests = new Queue<int>();

            //create a session object
            AccCreateSession(typeof(IAccSession).GUID, ref tmp);

            //cast to session, tell EventHandler that we have a session, then subscribe to the events we want
            accSess = (AccSession)tmp;
            EventHandler.Session = accSess;
            EventHandler.Subscribe();

            //set Identity for AIM 
            accSess.ClientInfo.set_Property(AccClientInfoProp.AccClientInfoProp_Description, "FAim/" + System.Windows.Forms.Application.ProductVersion + " " + GetRandomAccKey());

        }


        /// <summary>
        /// Gets a random AIM key from the database
        /// </summary>
        /// <returns></returns>
        private static String GetRandomAccKey()
        {

            //get keys from DB
            List<String> lstKeys = GetAccKeys();

            //Random number generator
            Random rnd = new Random();

            //return a random key
            return lstKeys[rnd.Next(0, lstKeys.Count)];

        }

        /// <summary>
        /// Retrieves all AIM keys from the database
        /// </summary>
        /// <returns></returns>
        private static List<String> GetAccKeys()
        {

            //list of keys
            List<String> lstKeys = null;

#if DEBUG 
            //get development keys
            lstKeys = Data.QueryManager.DevKeys();
#else
            //get release keys
            lstKeys = Data.QueryManager.ReleaseKeys();

#endif

            //return the list
            return lstKeys;

        }

        /// <summary>
        /// Attempt to Sign In to the AIM Network.
        /// </summary>
        /// <param name="user">The Screen Name to login as.</param>
        /// <param name="password">The Password for the Screen Name.</param>
        public static void SignOn(String user, String password)
        {

            //set sign in params.
            accSess.Identity = user;
            accSess.SignOn(password);

        }

        /// <summary>
        /// Sign off of the AIM Network.
        /// </summary>
        public static void SignOff()
        {

            //if wer online, sign off
            if ((accSess != null) && (accSess.State == AccSessionState.AccSessionState_Online))
                accSess.SignOff();

        }

        /// <summary>
        /// Gets the Position of the Group in the BuddyList
        /// </summary>
        /// <param name="GroupName">The name of the Group to get the Position of.</param>
        /// <returns>Returns an int for the position.</returns>
        public static int GroupPosition(String GroupName)
        {

            //get the buddy list
            IAccBuddyList bl = accSess.BuddyList;

            //get the group
            IAccGroup grp = bl.GetGroupByName(GroupName);

            //sanity check: null group
            if (grp == null)
                return -1;

            //return the position
            return bl.GetGroupPosition(grp);

        }

        /// <summary>
        /// Gets the Position of the Buddy in the specified Group.
        /// </summary>
        /// <param name="BuddyName">The Name of the Buddy to get the Position of.</param>
        /// <param name="GroupName">The Name of the Group the specified Buddy belongs to.</param>
        /// <returns>Returns the Position of the specified Buddy.</returns>
        public static int BuddyPosition(String BuddyName, String GroupName)
        {

            //get the buddy list
            IAccBuddyList bl = accSess.BuddyList;

            //get the group
            IAccGroup grp = bl.GetGroupByName(GroupName);

            //get the buddy
            IAccUser usr = bl.GetBuddyByName(BuddyName);

            //sanity check: null group
            if (grp == null)
                return -1;

            //return the Buddy's position
            return grp.GetBuddyPosition(usr);

        }

        /// <summary>
        /// Gets the number of Buddies in the specified Group.
        /// </summary>
        /// <param name="GroupName">The Group Name to check the number of Buddies.</param>
        /// <returns>Returns the number of Buddies int he specified Group.</returns>
        public static int NumberOfBuddiesInGroup(String GroupName)
        {

            //get the buddy list
            IAccBuddyList bl = accSess.BuddyList;

            //get the group
            IAccGroup grp = bl.GetGroupByName(GroupName);

            //return the number
            return grp.BuddyCount;

        }

        /// <summary>
        /// Gets if the Buddy is Idle. This is necessary because Buddies are not always reported as Idle for some strange AOL known reason.
        /// </summary>
        /// <param name="BuddyName">The Name of the Buddy to check.</param>
        /// <returns>Returns true if the Buddy is Idle, false else.</returns>
        public static void CheckBuddyIdle(String BuddyName)
        {

            //get the buddy list
            IAccBuddyList bl = accSess.BuddyList;

            //get the user
            IAccUser usr = bl.GetBuddyByName(BuddyName);

            //sanity check: null user
            if (usr == null)
                return;

            //request idle
            usr.RequestProperty(AccUserProp.AccUserProp_IdleTime);

        }

        /// <summary>
        /// Retreives the Buddys Status, including Away Message if applicable.
        /// </summary>
        /// <param name="BuddyName">The name of the Buddy to get the info of.</param>
        public static void GetBuddyInfo(String BuddyName)
        {

            //request the away message of the buddy
            queueComboRequests.Enqueue(accSess.BuddyList.GetBuddyByName(BuddyName).RequestProperty(AccUserProp.AccUserProp_AwayMessage));

            //request buddy info
            queueComboRequests.Enqueue(accSess.BuddyList.GetBuddyByName(BuddyName).RequestProperty(AccUserProp.AccUserProp_Profile));

        }

        /// <summary>
        /// Sends an IM to the specified session
        /// </summary>
        /// <param name="RtfToSend">The RTF text to send.</param>
        /// <param name="imSes">The IM Session to send to.</param>
        public static void SendIm(System.Windows.Forms.RichTextBox box, IAccImSession imSes)
        {

            //im to send
            IAccIm im = null;

            //converted text
            String strConverted = "";

            //convert
            strConverted = ConvertToHtml(box);

            //create and send im
            im = accSess.CreateIm(strConverted, "");
            imSes.SendIm(im);
            
        }

        /// <summary>
        /// Convert RTF to HTML....ish. This is more of a hack I found at: http://www.developer.com/net/vb/article.php/10926_1576561_3, all credit due there. This 
        /// was rewritten and tweaked for this app however.
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static string ConvertToHtml(System.Windows.Forms.RichTextBox box)
        {

            // Takes a RichTextBox control and returns a
            // simple HTML-formatted version of its contents
            String strHTML = "";
            String strColour = "";
            String strBackColor = "";
            bool blnBold = false;
            bool blnItalic = false;
            bool blnUnderline = false;
            String strFont = "";
            float fltSize = 0;
            int lngOriginalStart = 0;
            int lngOriginalLength = 0;
            
            // If nothing in the box, exit
            if (box.Text.Length == 0)
                return "";

            // Store original selections, then select first character
            lngOriginalStart = 0;
            lngOriginalLength = box.Text.Length;

            // Add HTML header
            strHTML = "<html>";

            // Set up initial parameters
            strColour = ColorTranslator.ToHtml(box.SelectionColor);
            strBackColor = ColorTranslator.ToHtml(box.SelectionBackColor);
            blnBold = box.SelectionFont.Bold;
            blnItalic = box.SelectionFont.Italic;
            blnUnderline = box.SelectionFont.Underline;
            strFont = box.SelectionFont.FontFamily.Name;
            fltSize = box.SelectionFont.Size;

            //Include first 'style' parameters in the HTML
            strHTML += "<span style=\"font-family: " + strFont + "; font-size: " + fltSize + "pt; color: " + strColour + "; background-color: " + strBackColor + "\">";
            strHTML = strHTML.Replace("\\", "");

            // Include bold tag, if required
            if (blnBold == true)
                strHTML += "<b>";

            //Include italic tag, if required
            if (blnItalic == true)
                strHTML += "<i>";

            //include underline tag, if required
            if (blnUnderline == true)
                strHTML += "<u>";

            //Finally, add our first character
            strHTML += box.Text.Substring(0, 1);

            //Loop around all remaining characters
            for (int i = 1; i < box.Text.Length; i++)
            {

                //If this is a line break, add HTML tag
                if (box.Text.Substring(i, 1) == Convert.ToChar(10).ToString())
                    strHTML += "<br />";

                // Check/implement any changes in style
                if ((ColorTranslator.ToHtml(box.SelectionColor) != strColour) || (box.SelectionFont.FontFamily.Name != strFont) ||
                   (box.SelectionFont.Size != fltSize) || (ColorTranslator.ToHtml(box.SelectionBackColor) != strBackColor))
                {
                    strHTML += "</span><span style=\"font-family: " + box.SelectionFont.FontFamily.Name + "; font-size: " + box.SelectionFont.Size + "pt; color: " 
                            + ColorTranslator.ToHtml(box.SelectionColor) + "; background-color: " + ColorTranslator.ToHtml(box.SelectionBackColor) + "\">";
                    strHTML = strHTML.Replace("\\", "");

                }

                // Check for bold changes
                if (box.SelectionFont.Bold != blnBold)
                {
                    if (box.SelectionFont.Bold == false)
                        strHTML += "</b>";
                    else
                        strHTML += "<b>";
                }

                // Check for italic changes
                if (box.SelectionFont.Italic != blnItalic)
                {
                    if (box.SelectionFont.Italic == false)
                        strHTML += "</i>";
                    else
                        strHTML += "<i>";
                }

                //check for underline changes
                if (box.SelectionFont.Underline != blnUnderline)
                {
                    if (box.SelectionFont.Underline == false)
                        strHTML += "</u>";
                    else
                        strHTML += "<i>";
                }

                // Add the actual character
                //strHTML += Mid(box.Text, intCount, 1);
                strHTML += box.Text.Substring(i, 1);

                // Update variables with current style
                strColour = ColorTranslator.ToHtml(box.SelectionColor);
                strBackColor = ColorTranslator.ToHtml(box.SelectionBackColor);
                blnBold = box.SelectionFont.Bold;
                blnItalic = box.SelectionFont.Italic;
                strFont = box.SelectionFont.FontFamily.Name;
                fltSize = box.SelectionFont.Size;

            }

            // Close off any open bold/italic/underline tags
            if (blnBold == true)
                strHTML += "</b>";
            if (blnItalic == true)
                strHTML += "</i>";
            if (blnUnderline == true)
                strHTML += "</u>";

            //Terminate outstanding HTML tags
            strHTML += "</span></html>";

            //Restore original RichTextBox selection
            box.Select(lngOriginalStart, lngOriginalLength);

            // Return HTML
            return strHTML;

        }

        public static IAccImSession CreateOrGetSession(String User, AccImSessionType Type)
        {
            return accSess.CreateImSession(User, Type);
        }

        public static IAccImSession CreateOrGetSession(IAccUser User, AccImSessionType Type)
        {
            return CreateOrGetSession(User.Name, Type);
        }

    }
}
