using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class CloseUpgradePopup
    {
        public static void closeButton_Click(object sender, EventArgs e)
        {
            Styling.AddUpgradePopup.ContainerPanel.Visible = false;
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddUpgradePopup.AddUpgradeButton);

            Methods.ControlsActive.EnableControls();
        }




    }
}
