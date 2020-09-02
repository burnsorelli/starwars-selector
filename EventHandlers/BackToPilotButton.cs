using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class BackToPilotButton
    {
        public static void backToPilot_Click(object sender, EventArgs e)
        {
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            var _ship = TrackerVariables.TrackedVariables.SelectedPilot.Ship;
            Methods.PopulatePilotChoices.GetPilots(_ship);
        }
    }
}
