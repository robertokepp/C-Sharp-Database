using System.Data.OleDb;

namespace DatabaseApp
{
    public class DatabaseMicrosoftAccess
    {
        private const string dbPath = @"PATH_FILE";
        private const string dbFullPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath;

        static DatabaseMicrosoftAccess unique = null;

        OleDbConnection uniqueConnection = null;

        public string getdbFullPath()
        {
            return dbFullPath;
        }

        public DatabaseMicrosoftAccess()
        {
            uniqueConnection = new OleDbConnection(dbFullPath);
        }

        static public DatabaseMicrosoftAccess GetProvider()
        {
            if (unique == null)
            {
                unique = new DatabaseMicrosoftAccess();
            }
            return unique;
        }

        public OleDbConnection GetConnection
        {
            get { return uniqueConnection; }
        }
    }
}
