using DatabaseApp.Database;

namespace DatabaseApp.Table
{
    public class TableMySQL
    {
        public bool checkLogin(string _username, string _password)
        {
            int Count = 0;
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM users WHERE username = '" + _username + "' and password = '" + _password + "'", connect);
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
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM users WHERE username = '" + _username + "'", connect);
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
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO users ([username],[password]) VALUES ('" + _username + "','" + _password + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void delete(string _username)
        {
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM users WHERE username = '" + _username + "'", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void modify(string _id, string _username, string _password)
        {
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("UPDATE users SET [username]='" + _username + "',[password]='" + _password + "' WHERE [id]= '" + _id + "'", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public System.Data.DataTable load()
        {
            var connect = DatabaseMySQL.GetProvider().GetConnection;
            connect.Open();
            var command = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM users", connect);
            var adaper = new MySql.Data.MySqlClient.MySqlDataAdapter(command);
            var table = new System.Data.DataTable();
            adaper.Fill(table);
            connect.Close();
            return table;
        }
    }
}
