using System;
using System.Data.SqlClient;

namespace AdoNetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // the classic way to connect sql to c# is with ADO.net
            //ADO.Net has classes in th esystem.data namespace

            //first the most traditional is

            //we need some Nuget package for the data provider (sql server)

            //--connected architecture with ADO.NET:

            //To connect to any data source from a code point of view 
            //we use a connection string

            //to avoid commiting login and password to public GitHub it will read from a gitignore class
            //

            var connectionString = SecretConfig.ConectionString;
            Console.WriteLine("Enter condition or press enter for no condition:");
            var input = Console.ReadLine();
            var commandString = "Select * from Poke.Pokemon";
            if(input.Length > 0)
            {
                commandString += $" Where {input}"; 
            }
            //we will be lazt and not try catch exceptions
            using (var connection = new SqlConnection(connectionString))
            {
                //1. open the connection
                connection.Open();

                //2. execute your query
                using (var command = new SqlCommand(commandString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //executeReader method on the SQLCOmand class
                        //returns a DataReader with provides each row as it comes in over the network

                        //if the command is not select,
                        //instead we use ExecuteNonQuery method, which returns int(number of rows affected)

                        //3. process the results
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var name = reader["Name"]; // can access columns by name (returns object)
                                var id = reader.GetInt32(0); // can access column by index, by type

                                Console.WriteLine($"{id}: {name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows returned");
                        }

                        //4. close the connection
                        connection.Close();
                        // (would be done by using block but good to be explicit)
                    }
                }
            }
        }
    }
}