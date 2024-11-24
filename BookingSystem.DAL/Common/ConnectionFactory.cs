using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common
{

    public class ConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Create()
            => new(_connectionString);
        public static SqlConnection Create(IConfiguration configuration)
           => new(configuration.GetConnectionString("defaultDatabase"));
        public static SqlConnection Create(IConfiguration configuration, string dbName)
          => new(configuration.GetConnectionString(dbName));
        public static SqlConnection Create(string connectionString)
          => new(connectionString);
    }
}
