using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;
using System.Windows.Forms;
using System.Data;

namespace Xwing.MySqlConnectionSetup
{
    //Returns a datatable for whatever query has been sent
    class MySqlConn
    {
        public static string myConnection = "datasource=localhost;port=3306;username=root;password=MysqlMarcusEll1s";
        public static string Output = "";
        private static DataTable dataTable = new DataTable();
        public static DataTable GetMySqlConnection(string query)
        {
            try
            {
                
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmd = new MySqlCommand(query, myConn);
                myConn.Open();

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(cmd);
                myDataAdapter.Fill(dataTable);

                myConn.Close();
                myDataAdapter.Dispose();
                return dataTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
