using AdoNetConnected;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDisconnected
{
    static class Program
    {
        static void Main()
        {
            var connectionString = SecretConfig.ConectionString;
            var commandString = "SELECT * FROM Poke.Pokemon;";
            var dataSet = new DataSet();

            // disconnected architecture
            // for the sake of performance when the DB is the bottleneck for an app,
            // we minimize the time we spend connected to the DB and iterating over results.

            using (var connection = new SqlConnection(connectionString))
            {
                // 1. open the connection
                connection.Open();

                using (var command = new SqlCommand(commandString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    // in disconnected architecture, we don't work directly with the DataReader
                    // instead, we use a DataAdapter to fill a DataSet with the results.

                    // 2. execute the query (filling the DataSet)
                    adapter.Fill(dataSet);
                }

                // 3. close the connection
                connection.Close();
            }

            // 4. process the results

            // connected architecture is faster when the DB is not congested with many connections
            //    (less overhead; no DataSet filling to do)
            // but disconnected is faster overall when the bottleneck is those DB connections

            // DataSets contain DataTables with DataColumns and DataRows
            // iterate over the rows of the first table (only table)
            DataTable table = dataSet.Tables[0];
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("No rows returned.");
            }
            foreach (DataRow row in table.Rows)
            {
                string name = (string)row["name"];

                DataColumn column = table.Columns["PokemonId"];
                int id = (int)row[column];

                Console.WriteLine($"{id}: {name}");
            }
        }
    }
}
