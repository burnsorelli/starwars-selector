using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.EventHandlers
{
    class AddUpgradeButton
    {
        public static void addUpgrade_Click(object sender, EventArgs e, bool _add)
        {
            if (_add)
            {
                Methods.AddUpgrade.Add();
            }
            else
            {
                Methods.RemoveUpgrade.Remove();
            }

            Methods.ControlsActive.EnableControls();
        }
    }
}
