using MySql.Data.MySqlClient;

namespace DatabaseApp.Database
{
    class DatabaseMySQL
    {
        private const string server = "localhost;";
        private const string port = "3306;uid=root;pwd=;database=DBProyect;";
        private const string username = "root";
        private const string password = "";
        private const string database = "";
        private const string dbFullPath = "server=" + server + ";port=" + port + ";uid=" + username + ";pwd=" + password + ";database=" + database + ";";

        static DatabaseMySQL unique = null;

        MySqlConnection uniqueConnection = null;

        private DatabaseMySQL()
        {
            uniqueConnection = new MySqlConnection(dbFullPath);
        }

        static public DatabaseMySQL GetProvider()
        {
            if (unique == null)
            {
                unique = new DatabaseMySQL();
            }
            return unique;
        }

        public MySqlConnection GetConnection
        {
            get { return uniqueConnection; }
        }
    }
}