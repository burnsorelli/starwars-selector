using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class PopulatePilotChoices
    {
        public static void GetPilots(string _ship)
        {
            string _faction = TrackerVariables.TrackedVariables.FactionChosen;
            string _query = "Select Pilot, Description, Points, Pilot_skill, Attack, Agility, Hull, Shield, Pilot_Pic_Location" + 
                " from starwars_xwing.Pilots where Ship ='" + _ship + "' and Faction ='" + _faction + "' order by Pilot ;";
            DataTable _tmpDT = new DataTable();
            _tmpDT = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);
            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Styling.MainPageChoices.GetElements(_tmpDT, "pilot");
        }
    }
}
