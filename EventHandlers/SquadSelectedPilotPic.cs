using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class SquadSelectedPilotPic
    {

        public static void pic_Click(object sender, EventArgs e, bool _add)
        {
            var _pictureBox = (PictureBox)sender;
            foreach (var _pilot in TrackerVariables.TrackedVariables.PilotList)
            {
                if (_pilot.UniqueId.ToString() == _pictureBox.Name)
                {
                    _add = false;
                    TrackerVariables.TrackedVariables.SelectedPilot = _pilot;
                    break;
                }
            }
            Styling.AddPilotPopup.GetElements(_add);
            
        }
    }
}
