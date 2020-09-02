using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.Methods
{
    class GetUpgradeDetailsString
    {
        private static string _upgradeDetails = "";

        public static string GetDetails()
        {
            var _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;
            _upgradeDetails = "";
            _upgradeDetails +=
                "Name: " + _upgrade.Name +
                "\r\nDescription: " + _upgrade.Description +
                "\r\nPoints: " + _upgrade.Points +
                "\r\nType: " + _upgrade.Type;
            return _upgradeDetails;
        }
    }
}
