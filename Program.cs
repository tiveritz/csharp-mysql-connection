using System;


namespace csharp_mysql_connection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World C# .NET MySql");
            Console.WriteLine("-------------------------");

            // Use a custom MySQL class -> hide connection data in production!
            MySqlConnector mySql = new MySqlConnector("127.0.0.1", "develop", "develop", "develop_pass");

            // Query statements
            // You can use Verbatim literals (@) for multiline statements

            mySql.Query(@"CREATE TABLE IF NOT EXISTS example (
                        id int PRIMARY KEY AUTO_INCREMENT,
                        name varchar(100) NOT NULL,
                        age int NOT NULL)"
                        );
                        
            mySql.Query(@"INSERT INTO example (name, age)
                        VALUES ('ignatz', 55)"
                        );

            mySql.Query(@"INSERT INTO example (name, age)
                        VALUES ('asdf', 22)"
                        );

            // With Prepared Statements
            mySql.PreparedQuery("new name", 30);

            // Get data from database and print
            mySql.PrintAll();
        }
    }
}
