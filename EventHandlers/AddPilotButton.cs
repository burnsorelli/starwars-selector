using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class AddPilotButton
    {
        public static void addPilot_Click(object sender, EventArgs e, bool _add)
        {
            Methods.AddPilot.Add(_add);
            //if (_add)
            //{
            //    Methods.AddPilot.Add(_add);
            //}
            Styling.AddPilotPopup.ContainerPanel.Visible = false;
            Methods.ControlsActive.EnableControls();
            //Button btn = (Button)sender;
            //Methods.RemoveEventHandlers.RemoveAllHandlers(btn);
        }
    }
}
