using System.Data.SqlClient;

namespace DatabaseApp.Database
{
    class DatabaseSQL
    {

        private const string dbPath = @"COMPUTER_NAME-PC\SQLEXPRESS";
        private const string dbFullPath = @"server=" + dbPath + ";Initial Catalog=SqlDataBase;Integrated Security=True";

        static DatabaseSQL unique = null;

        SqlConnection uniqueConnection = null;

        private DatabaseSQL()
        {
            uniqueConnection = new SqlConnection(dbFullPath);
        }

        static public DatabaseSQL GetProvider()
        {
            if (unique == null)
            {
                unique = new DatabaseSQL();
            }
            return unique;
        }

        public SqlConnection GetConnection
        {
            get { return uniqueConnection; }
        }
    }
}
