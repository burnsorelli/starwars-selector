using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Xwing.Methods
{
    class PopulateFactionChoices
    {
        private static string _query = "Select distinct Faction from starwars_xwing.pilots;";
        public static DataTable GetDataTable()
        {
            DataTable tmpDT = MySqlConnectionSetup.MySqlConn.GetMySqlConnection(_query);

            return tmpDT;

        }
       
    }
}
