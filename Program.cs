using System;


namespace csharp_mysql_connection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World C# .NET MySql");
            Console.WriteLine("-------------------------");

            MySqlConnector mySql = new MySqlConnector("127.0.0.1", "coding_campus", "coding_campus", "coding_campus_pass");

            mySql.Query(
                "CREATE TABLE IF NOT EXISTS example (" +
                "id int PRIMARY KEY AUTO_INCREMENT," +
                "name varchar(100) NOT NULL," +
                "age int NOT NULL" +
                ")"
			);
            mySql.Query("INSERT INTO example (name, age) VALUES ('ignatz', 55)");
            mySql.Query("INSERT INTO example (name, age) VALUES ('asdf', 22)");

            mySql.PrintAll();

        }
    }
}
