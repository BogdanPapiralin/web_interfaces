using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Microsoft.Data.SqlClient;


using SQLInfoRetriever;

namespace SQLInfoRetriever
{
    public class Retriever
    {
        public static string connectionString = "Server=DESKTOP-2PI0JS6;Database=Book;Integrated Security=true;Encrypt=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        public DataTable GetData(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}