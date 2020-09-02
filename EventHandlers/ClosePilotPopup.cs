using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class ClosePilotPopup
    {

        public static void closeButton_Click(object sender, EventArgs e)
        {
            Styling.AddPilotPopup.ContainerPanel.Visible = false;
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddPilotPopup.AddPilotButton);
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddPilotPopup.ChooseUpgradesButton);
            Methods.ControlsActive.EnableControls();
        }
    }
}
