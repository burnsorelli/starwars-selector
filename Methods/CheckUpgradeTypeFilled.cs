using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class CheckUpgradeTypeFilled
    {
        public static bool CheckFilled()
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            var _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;
            int _qtyAllowed = _pilot.UpgradeTypeQty[_upgrade.Type];
            bool _typeUsed = false;
            int _count = 0;
            foreach(NonStaticClasses.Upgrades _tmpUpgrade in _pilot.Upgrades)
            {
                if(_tmpUpgrade.Type == _upgrade.Type)
                {
                    _count += 1;
                }
            }

            if (_qtyAllowed <= _count)
            {
                _typeUsed = true;
                MessageBox.Show("You already have this upgrade type selected");
            }
            return _typeUsed;
        }
    }
}
