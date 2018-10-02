namespace DatabaseApp.Table
{
    public class TableMicrosoftAccess
    {
        public bool checkLogin(string _username, string _password)
        {
            int Count = 0;
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("SELECT * FROM users WHERE username = '" + _username + "' and password = '" + _password + "'", connect);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Count++;
            }

            connect.Close();

            if (Count == 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool checkUser(string _username)
        {
            int Count = 0;
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Uuers WHERE username = '" + _username + "'", connect);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Count++;
            }

            connect.Close();

            if (Count == 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void create(string _username, string _password)
        {
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("INSERT INTO users ([username],[password]) VALUES ('" + _username + "','" + _password + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void delete(string _username)
        {
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("DELETE FROM users WHERE username = '" + _username + "'", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void modify(string _id, string _username, string _password)
        {
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("UPDATE Users SET [username]='" + _username + "',[password]='" + _password + "' WHERE [id]= '" + _id + "'", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public System.Data.DataTable load()
        {
            var connect = DatabaseMicrosoftAccess.GetProvider().GetConnection;
            connect.Open();
            var command = new System.Data.OleDb.OleDbCommand("SELECT * FROM users", connect);
            var adaper = new System.Data.OleDb.OleDbDataAdapter(command);
            var table = new System.Data.DataTable();
            adaper.Fill(table);
            connect.Close();
            return table;
        }
    }
}