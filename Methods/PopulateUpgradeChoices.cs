using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class PopulateUpgradeChoices
    {

        public static void GetUpgrades(string _upgradeType) // needs picturebox passed?
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            int _boost;
            if(_pilot.Boost == true)
            {
                _boost = 1;
            }
            else
            {
                _boost = 0;
            }
            var _query = "select Up_Name, upg_id, type, description, points, restrictions, faction_restriction, ship_restriction, size_restriction, unique_upgrades, min_pilot_lvl, " +
                "Pilot_Skill, Attack, Agility, Hull, Shield, Modifications, Elite, Energy, Crew, Teams, Cannons, Torpedoes, Missiles, Illicit, Systems, Bombs, Cargo, SalvagedAstro, Title, Dual_Card, Needs_Boost, Max_Mod_Pts " +
                "from starwars_xwing.upgrades where type = '" + _upgradeType + "' and min_pilot_lvl <= " + _pilot.PilotSkill +
                " and (faction_restriction = '" + _pilot.Faction + "' or faction_restriction is NULL)" +
                " and (ship_restriction = '" + _pilot.Ship + "' or ship_restriction is NULL or ship_restriction = '" + _pilot.Ship_Type + "')" +
                " and (min_shield_lvl <= '" + _pilot.Shield + "')" +
                " and (Needs_Boost <= '" + _boost + "')" +
                " and (Points <= '" + _pilot.Max_Mod_Pts + "')" +
                " and (size_restriction = '" + _pilot.Size + "' or size_restriction is NULL)" +
                " and (Max_Hull_Lvl >= '" + _pilot.Hull + "' or Max_Hull_Lvl is NULL)" +
                " and (Min_Pilot_Agility <= '" + _pilot.Agility + "')" +
                //" and Include > '0';";
                " and Qty >= '0' order by Up_Name;";

            var tmpDT = new DataTable();
            tmpDT = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);

            TrackerVariables.TrackedVariables.CurrentListUpgrades.Clear();
            foreach(DataRow _row in tmpDT.Rows)
            {
                string _name = _row[0].ToString();
                int _id = Convert.ToInt32(_row[1]);
                string _type = _row[2].ToString();
                string _description = _row[3].ToString();
                int _points = Convert.ToInt32(_row[4]);
                string _restrictions = _row[5].ToString(); // how to get a boolean
                string _factionRestriction = _row[6].ToString();
                string _shipRestriction = _row[7].ToString();
                string _sizeRestriction = _row[8].ToString();
                string _unique = _row[9].ToString();
                int _minPilotLvl = Convert.ToInt32(_row[10]);
                int _pilotSkill = Convert.ToInt32(_row[11]);
                int _attack = Convert.ToInt32(_row[12]);
                int _agility = Convert.ToInt32(_row[13]);
                int _hull = Convert.ToInt32(_row[14]);
                int _shield = Convert.ToInt32(_row[15]);
                int _modifications = Convert.ToInt32(_row[16]);
                int _elite = Convert.ToInt32(_row[17]);
                int _energy = Convert.ToInt32(_row[18]);
                int _crew = Convert.ToInt32(_row[19]);
                int _teams = Convert.ToInt32(_row[20]);
                int _cannons = Convert.ToInt32(_row[21]);
                int _torpedoes = Convert.ToInt32(_row[22]);
                int _missiles = Convert.ToInt32(_row[23]);
                int _illicit = Convert.ToInt32(_row[24]);
                int _system = Convert.ToInt32(_row[25]);
                int _bombs = Convert.ToInt32(_row[26]);
                int _cargo = Convert.ToInt32(_row[27]);
                int _salvagedAstromech = Convert.ToInt32(_row[28]);
                int _title = Convert.ToInt32(_row[29]);
                string _dualCard = _row[30].ToString();
                int _max_Mod_Pts = Convert.ToInt32(_row[32]);
                var tmpUpgrade = new NonStaticClasses.Upgrades(_id, _type, _name, _description, _points, _restrictions, _factionRestriction, _shipRestriction, _sizeRestriction,
                    _unique, _minPilotLvl, _pilotSkill, _attack, _agility, _hull, _shield, _modifications, _elite, _energy, _crew, _teams, _cannons, _torpedoes, _missiles, _illicit,
                    _system, _bombs, _cargo, _salvagedAstromech, _title, _dualCard, _max_Mod_Pts);
                TrackerVariables.TrackedVariables.CurrentListUpgrades.Add(tmpUpgrade);
            }

            Styling.MainPageChoices.ContainerPanel.Controls.Clear();
            Styling.MainPageChoices.GetElements(tmpDT, "upgrades");
            tmpDT.Clear();
            tmpDT.Columns.Clear();
        }

        
    }
}
