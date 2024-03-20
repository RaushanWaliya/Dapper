using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUD_Application.DapperContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connctionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connctionString = _configuration.GetConnectionString("DataBase");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connctionString);
    }
}
