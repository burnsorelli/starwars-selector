using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Xwing.EventHandlers
{
    class PilotChoicePic
    {

        public static void pilot_Click(object sender, EventArgs e)
        {
            PictureBox _clickedPic = (PictureBox)sender;
            string _name = _clickedPic.Name;
            Methods.GetPilotDetails.getDetails(_name);
        }
    }
}
