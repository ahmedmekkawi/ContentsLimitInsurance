using Microsoft.Data.SqlClient;
using System.Data;

namespace ContentsLimitInsurance.Interfaces
{
    public interface ISvcDbConnection : ISvc
    {
        SqlCommand OpenDbConnection(string name, CommandType commandType);
        void CloseDbConnection();
    }
}
