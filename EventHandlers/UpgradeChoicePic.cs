using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class UpgradeChoicePic
    {
        public static void upgrade_Click(object sender, EventArgs e, bool _add)
        {
            var _clickedUpgrade = (PictureBox)sender;
            
            if (!_add)
            {
                
                Styling.AddPilotPopup.ContainerPanel.Visible = true;
                foreach (NonStaticClasses.Upgrades _upgrade in TrackerVariables.TrackedVariables.SelectedPilot.Upgrades)
                {
                    if (_upgrade.Name == _clickedUpgrade.Name)
                    {
                        TrackerVariables.TrackedVariables.SelectedUpgrade = _upgrade;
                    }
                }
            }

            foreach (var upgrade in TrackerVariables.TrackedVariables.CurrentListUpgrades)
            {
                if (upgrade.Name == _clickedUpgrade.Name)
                {
                    TrackerVariables.TrackedVariables.SelectedUpgrade = upgrade;
                    break;
                }
            }

            
            Styling.AddUpgradePopup.GetElements(_add);
            // CURRENTLY THE OLD STYLING
            //MainPage.AvailableChoicesPanel.AddUpgradePanel.AddUpgradePanelStyling.GetElements(_add);

        }
    }
}
