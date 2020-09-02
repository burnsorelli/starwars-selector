using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class ChooseUpgradesButton
    {

        public static void chooseUpgradesButton_Click(object sender, EventArgs e, bool _add)
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            if (_add)
            {
                Methods.AddPilot.Add(_add);
            }
            Styling.AddPilotPopup.ContainerPanel.Visible = false;
            Methods.PopulateUpgradeTypeChoices.GetUpgradeChoices();
            Methods.ControlsActive.EnableControls();
            //Button btn = (Button)sender;
            //Methods.RemoveEventHandlers.RemoveAllHandlers(btn);

        }
    }
}
