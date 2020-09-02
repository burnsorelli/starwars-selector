using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class ShipChoicePic
    {
        public static void ship_Click(object sender, EventArgs e)
        {
            PictureBox _clickedPic = (PictureBox)sender;
            string _ship = _clickedPic.Name;
            Methods.PopulatePilotChoices.GetPilots(_ship);
        }
    }
}
