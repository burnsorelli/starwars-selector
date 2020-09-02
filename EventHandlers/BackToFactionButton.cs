using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class BackToFactionButton
    {

        public static void backFaction_Click(object sender, EventArgs e)
        {
            Styling.MainPageOutline.ContainerPanel.Controls.Clear();
            Styling.MainPageOutline.ContainerPanel.Visible = false;
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Styling.StartPage.GetElements();

            // ORIGINAL FILE LOCATION!!!
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            
            //MainPage.MainPageHeaderPanel.HeaderPanelStyling.ChosenSquadPanel.Controls.Clear();

            TrackerVariables.TrackedVariables.PilotList.Clear();
            Methods.ResetUniqueId.Reset();

        }

    }
}
