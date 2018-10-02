using DatabaseApp.Database;
using System.Data;

namespace DatabaseApp.Test
{
    public class TestSQL
    {
        public static bool testConnection()
        {
            var Connect = DatabaseSQL.GetProvider().GetConnection;

            Connect.Open();

            if (Connect.State == ConnectionState.Open)
            {
                Connect.Close();
                return true;
            }

            else
            {
                Connect.Close();
                return false;
            }
        }
    }
}
