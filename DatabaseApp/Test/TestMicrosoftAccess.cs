using System.IO;

namespace DatabaseApp.Test
{
    public class TestMicrosoftAccess
    {
        static bool checkPath = false;

        public static bool testConnection()
        {
            DatabaseMicrosoftAccess Connect = new DatabaseMicrosoftAccess();

            checkPath = File.Exists(Connect.getdbFullPath());

            if (checkPath == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
