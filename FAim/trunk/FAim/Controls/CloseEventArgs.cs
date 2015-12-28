using System;

namespace FAim.Controls
{
    public class CloseEventArgs
    {

        //tab index
        private int intTabIndex = -1;

        /// <summary>
        /// Gets or Sets the tab index value where the close button is clicked
        /// </summary>
        public int TabIndex
        {
            get { return intTabIndex; }
            set { this.intTabIndex = value; }
        }


        /// <summary>
        /// Constructs a new CloseEventArgs object
        /// </summary>
        /// <param name="nTabIndex"></param>
        public CloseEventArgs(int nTabIndex)
        {
            intTabIndex = nTabIndex;
        }

    }
}
