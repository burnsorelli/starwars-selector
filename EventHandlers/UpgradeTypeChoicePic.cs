using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.EventHandlers
{
    class UpgradeTypeChoicePic
    {
        public static void upgradeType_Click(object sender, EventArgs e)
        {
            PictureBox _clickedUpgradeType = (PictureBox)sender;
            Methods.PopulateUpgradeChoices.GetUpgrades(_clickedUpgradeType.Name);
            //Methods.PopulateUpgradeTypeChoices.GetUpgradeChoices();
        }
    }
}
