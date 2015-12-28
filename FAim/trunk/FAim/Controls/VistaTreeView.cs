using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FAim.Controls
{
    class VistaTreeView : TreeView
    {

        public VistaTreeView()
        {

            //make it a Vista style tree view
            Win32Api.SetWindowTheme(this.Handle, "explorer", null);
            this.HotTracking = true; //important
            this.ShowLines = false;
            Win32Api.SendMessage(this.Handle, Win32Api.TVM_SETEXTENDEDSTYLE, 0, Win32Api.TVS_EX_FADEINOUTEXPANDOS);

        }

    }
}
