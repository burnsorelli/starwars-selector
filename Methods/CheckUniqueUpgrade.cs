using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class CheckUniqueUpgrade
    {
        public static bool CheckUnique()
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            var _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;
            bool _alreadyUsed = false;

            if (_upgrade.UniqueUpgrade == "Yes")
            {
                foreach(NonStaticClasses.Pilots _tmpPilot in TrackerVariables.TrackedVariables.PilotList)
                {
                    foreach (NonStaticClasses.Upgrades _tmpUpgrade in _tmpPilot.Upgrades)
                    {
                        if (_upgrade.Name == _tmpUpgrade.Name)
                        {
                            _alreadyUsed = true;
                            MessageBox.Show("Already used");
                        }
                    }
                }
            }
            return _alreadyUsed;
        }
    }
}
