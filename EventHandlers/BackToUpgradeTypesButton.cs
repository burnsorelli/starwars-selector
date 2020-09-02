using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class BackToUpgradeTypesButton
    {
        public static void backToUpgradeTypes_Click(object sender, EventArgs e)
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            TrackerVariables.TrackedVariables.CurrentListUpgrades.Clear();
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Methods.PopulateUpgradeTypeChoices.GetUpgradeChoices();
        }
    }
}
