using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class BackToShipButton
    {
        public static void backToShip_Click(object sender, EventArgs e)
        {
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Methods.PopulateShipChoices.GetShips();
        }
    }
}
