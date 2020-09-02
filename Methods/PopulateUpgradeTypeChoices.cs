using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class PopulateUpgradeTypeChoices
    {
        public static void GetUpgradeChoices()
        {
            string _pilotName = TrackerVariables.TrackedVariables.SelectedPilot.Name;
            int _pilot_Id = TrackerVariables.TrackedVariables.SelectedPilot.Pilot_Id;
            string _faction = TrackerVariables.TrackedVariables.FactionChosen;
            List<string> _upgradeList = new List<string>();

            foreach (KeyValuePair<string, int> _upgrade in TrackerVariables.TrackedVariables.SelectedPilot.UpgradeTypeQty)
            {
                if (_upgrade.Value > 0)
                {
                    _upgradeList.Add(_upgrade.Key);
                }
            }

            _upgradeList.Sort();

            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Styling.MainPageChoices.GetElements(null, "upgradeTypes", _upgradeList);

            //string _query = "select c.Upgrades, c.Quantity, p.Pilot, p.Faction from starwars_xwing.connections c " +
            //    "inner join starwars_xwing.pilots p on p.Pilot = c.Pilot where c.pilot = '" + _pilotName + "' and" + 
            //    " p.faction = '" + _faction + "';";

            //string _query = "select c.Upgrades, c.Quantity, p.Pilot, p.Faction from starwars_xwing.connections c " +
            //        "inner join starwars_xwing.pilots p on p.Pilot = c.Pilot where c.Pilot_ID = '" + _pilot_Id + "' and" +
            //        " p.faction = '" + _faction + "';";

            //DataTable _tmpDT = new DataTable();
            //_tmpDT = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);
            //Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            //Styling.MainPageChoices.GetElements(_tmpDT, "upgradeTypes");
        }
    }
}
