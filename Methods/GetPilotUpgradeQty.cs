using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class GetPilotUpgradeQty
    {
        public static Dictionary<string, int> GetUpgradeQty(int _pilot_ID)
        {
            //string tmpName = _pilotName.Replace("'", "''");

            Dictionary<string, int> tmpDict = new Dictionary<string, int>();
            string query = "Select Upgrades, Quantity from starwars_xwing.connections where Pilot_ID = '" + _pilot_ID + "';";
            DataTable tmpDataTable = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(query);

            foreach (DataRow row in tmpDataTable.Rows)
            {
                tmpDict.Add(row[0].ToString(), Convert.ToInt32(row[1]));
            }
            tmpDataTable.Clear();
            tmpDataTable.Columns.Clear();
            return tmpDict;
        }
        //public static Dictionary<string, int> GetUpgradeQty(string _pilotName, int test)
        //{
        //    string tmpName = _pilotName.Replace("'", "''");

        //    Dictionary<string, int> tmpDict = new Dictionary<string, int>();
        //    string query = "Select Upgrades, Quantity from starwars_xwing.connections where pilot = '" + tmpName + "';";
        //    DataTable tmpDataTable = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(query);

        //    foreach (DataRow row in tmpDataTable.Rows)
        //    {
        //        tmpDict.Add(row[0].ToString(), Convert.ToInt32(row[1]));
        //    }
        //    tmpDataTable.Clear();
        //    tmpDataTable.Columns.Clear();
        //    return tmpDict;
        //}
    }
}
