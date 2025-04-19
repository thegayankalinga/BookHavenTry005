using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Connections
{
    public class DatabaseService
    {

        private readonly string? _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string is null or empty");
            }
        }

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection failed");
                    Console.WriteLine(ex.Message);
                }
                //finally
                //{
                //    connection.Close();
                //}
            }
        }

        public SqlConnection GetConnectin()
        {
            TestConnection();
            return new SqlConnection(_connectionString);
        }
    }
}
