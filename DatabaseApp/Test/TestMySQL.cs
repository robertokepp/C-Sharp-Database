using DatabaseApp.Database;
using System.Data;

namespace DatabaseApp.Test
{
    public class TestMySQL
    {
        public static bool testConnection()
        {
            var MySqlConnect = DatabaseMySQL.GetProvider().GetConnection;

            MySqlConnect.Open();

            if (MySqlConnect.State == ConnectionState.Open)
            {
                MySqlConnect.Close();
                return true;
            }

            else
            {
                MySqlConnect.Close();
                return false;
            }
        }
    }
}
