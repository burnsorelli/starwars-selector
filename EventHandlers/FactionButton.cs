using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class FactionButton
    {

        public static void factionButton_Click(object sender, EventArgs e)
        {
            Button factionButton = (Button)sender;
            TrackerVariables.TrackedVariables.FactionChosen = factionButton.Text;
            Styling.MainPageOutline.GetElements();
            Styling.HeaderOutline.GetElements();
            Styling.HeaderTotalScore.GetElements();
            Methods.PopulateShipChoices.GetShips();
            Styling.StartPage.FactionPanel.Visible = false;
        }
    }
}
