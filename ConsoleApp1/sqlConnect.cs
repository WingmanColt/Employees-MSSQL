using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp1
{
   public class sqlConnect
    {
        public sqlConnect()
        { 
        var connectionString =
        @"Server=DESKTOP-T0CRUT7;" +
        @"Database=SoftUni;" +
        @"Integrated Security=True";

        var connection = new SqlConnection(connectionString);
        connection.Open();

            using (connection)
            {
                var cmdText = @"SELECT * FROM Employees";
                var cmd = new SqlCommand(cmdText, connection);

                var dataReader = cmd.ExecuteReader();

                var employees = new List<Employee>();

                while(dataReader.Read())
                {
                    var firstName = (string) dataReader["FirstName"];
                    var lastName = dataReader["LastName"].ToString();
                    var jobTitle = dataReader["JobTitle"].ToString();

                    Employee employee = new Employee(firstName, lastName, jobTitle);
                    employees.Add(employee);
                }

                var groups = employees.GroupBy(e => e.jobTitle).OrderByDescending(e => e.Key);
                var spaces = new string(' ', 4);
                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var e in g)
                    {
                        Console.WriteLine(spaces + e.firstName + " " + e.lastName);
                    }

                }
            }


        }

    }
}
