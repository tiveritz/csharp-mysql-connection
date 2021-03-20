using System;
using MySql.Data.MySqlClient;

namespace csharp_mysql_connection
{
    class MySqlConnector
    {
        private MySqlConnection SQL;

        public MySqlConnector(string server, string db, string user_id, string user_pass) {
            string connection = "Server = " + server + "; Database = " + db + "; Uid = " + user_id + "; Pwd = " + user_pass;

            this.SQL = new MySqlConnection();
            SQL.ConnectionString = connection;
        }

        public void Query(string query)
        {
            MySqlCommand command = new MySqlCommand(query, SQL);

            SQL.Open();
            command.ExecuteNonQuery();
            SQL.Close();
        }

        public void PrintAll()
        {
            string query = "SELECT * FROM example";
            MySqlCommand command = new MySqlCommand(query, SQL);

            SQL.Open();
            MySqlDataReader data = command.ExecuteReader();

            while (data.Read()) {
                Console.WriteLine(data.GetString(0) + ", " + data.GetString(1) + ", " + data.GetString(2));
            }
            SQL.Close();
        }
    }
}
