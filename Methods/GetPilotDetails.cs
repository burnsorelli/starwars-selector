using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class GetPilotDetails
    {
        private static string _name;
        private static string _description;
        private static int _points;
        private static int _pilotSkill;
        private static int _attack;
        private static int _agility;
        private static int _hull;
        private static int _shield;
        private static string _uniquePilot;
        private static string _ship;
        private static string _faction;
        private static string _size;
        private static int _pil_Id;
        private static string _shipType;
        private static bool _boost;
        public static void getDetails(string name)
        {
            string tmpName = name.Replace("'", "''");
            string _query = "select Pilot, Description, Points, Pilot_skill, Attack, " +
                "Agility, Hull, Shield, Unique_Pilot, Ship, Faction, Size, pil_ID, Ship_Type, Boost_Icon from" +
                " starwars_xwing.Pilots where Pilot = '" + tmpName + "' and Faction = '" + TrackerVariables.TrackedVariables.FactionChosen + "';";
            DataTable _tmpDataTable = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);

            foreach (DataRow _row in _tmpDataTable.Rows)
            {
                _name = _row[0].ToString();
                _description = _row[1].ToString();
                _points = Convert.ToInt32(_row[2]);
                _pilotSkill = Convert.ToInt32(_row[3]);
                _attack = Convert.ToInt32(_row[4]);
                _agility = Convert.ToInt32(_row[5]);
                _hull = Convert.ToInt32(_row[6]);
                _shield = Convert.ToInt32(_row[7]);
                _uniquePilot = _row[8].ToString();
                _ship = _row[9].ToString();
                _faction = _row[10].ToString();
                _size = _row[11].ToString();
                _pil_Id = Convert.ToInt32(_row[12]);
                _shipType = _row[13].ToString();
                if(Convert.ToInt32(_row[14]) > 0)
                {
                    _boost = true;
                }
                else
                {
                    _boost = false;
                }
            }

            var _pilot = new NonStaticClasses.Pilots(_name, _description, _points, _pilotSkill, _attack,
                                                    _agility, _hull, _shield, _uniquePilot, _ship, _faction, _size, _pil_Id, _shipType, _boost);
            _tmpDataTable.Clear();
            _tmpDataTable.Columns.Clear();
            _pilot.UpgradeTypeQty = Methods.GetPilotUpgradeQty.GetUpgradeQty(_pil_Id);
            //_pilot.UpgradeTypeQty = Methods.GetPilotUpgradeQty.GetUpgradeQty(_name);
            TrackerVariables.TrackedVariables.SelectedPilot = _pilot;

            // OLD STYLING NEEDS TO CHANGE!!!
            Styling.AddPilotPopup.GetElements(true);
            Styling.AddPilotPopup.ContainerPanel.Visible = true;
        }
    }
}
