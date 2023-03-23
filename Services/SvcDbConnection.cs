using ContentsLimitInsurance.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ContentsLimitInsurance.Services
{
    public class SvcDbConnection : ISvcDbConnection
    {
        private readonly SqlConnection _connection;

        public SvcDbConnection()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            IConfiguration _configuration = builder.Build();
            var ConnectionString = _configuration.GetConnectionString("ContentsLimitInsurance");
            _connection = new SqlConnection(ConnectionString);
        }

        public SqlCommand OpenDbConnection(string name, CommandType commandType)
        {
            _connection.Open();
            return new SqlCommand()
            {
                CommandText = name,
                Connection = _connection,
                CommandType = CommandType.StoredProcedure
            };
        }

        public void CloseDbConnection()
        {
            _connection.Close();
        }
    }
}
