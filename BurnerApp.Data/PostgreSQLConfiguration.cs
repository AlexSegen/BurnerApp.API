using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnerApp.Data
{
    public class PostgreSQLConfiguration
    {
        public string _connectionString { get; set; }
        public PostgreSQLConfiguration(string ConnectionString) => _connectionString = ConnectionString;
    }
}
