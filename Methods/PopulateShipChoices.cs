using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class PopulateShipChoices
    {
        public static void GetShips()
        {
            string _faction = TrackerVariables.TrackedVariables.FactionChosen;
            string _query = "Select distinct Ship from starwars_xwing.Pilots where Faction = '" + _faction + "' order by Ship;";
            DataTable tmpDT = new DataTable();
            tmpDT = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);
            Styling.MainPageChoices.GetElements(tmpDT, "ship");
        }
    }
}
