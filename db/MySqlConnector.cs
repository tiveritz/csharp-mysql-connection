using System;
using MySql.Data.MySqlClient;

namespace csharp_mysql_connection
{
    class MySqlConnector
    {
        private MySqlConnection SQL;

        public MySqlConnector(string server, string db, string user_id, string user_pass) {
            string connection =
                "Server = " + server + "; "
                + "Database = " + db + "; "
                + "Uid = " + user_id + "; "
                + "Pwd = " + user_pass;

            this.SQL = new MySqlConnection(connection);

            // Alternative:
            // this.SQL = new MySqlConnection();
            // SQL.ConnectionString = connection;
        }

        public void Query(string query)
        {
            MySqlCommand command = new MySqlCommand(query, SQL);

            SQL.Open();
            command.ExecuteNonQuery();
            SQL.Close();
        }

        public void PreparedQuery(string name, int age)
        {
            // Don't put @ placeholders in quotes (name)
            string query = "INSERT INTO example (name, age) VALUES (@name, @age)";
            MySqlCommand command = new MySqlCommand(query, SQL);

            // Add values
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@age", age);

            // Open connection before Prepare()
            SQL.Open();
            command.Prepare();
            command.ExecuteNonQuery();
            SQL.Close();
        }

        public void PrintAll()
        {
            string query = "SELECT * FROM example";
            MySqlCommand command = new MySqlCommand(query, SQL);

            // Open connection before ExecuteReader()
            SQL.Open();
            MySqlDataReader data = command.ExecuteReader();

            while (data.Read()) {
                Console.WriteLine(
                    data.GetString(0) + ", "
                    + data.GetString(1) + ", "
                    + data.GetString(2));
            }
            SQL.Close();
        }
    }
}
