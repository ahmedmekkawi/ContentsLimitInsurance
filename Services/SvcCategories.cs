using ContentsLimitInsurance.Interfaces;
using ContentsLimitInsurance.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ContentsLimitInsurance.Services
{
    public class SvcCategories : ISvcCategories
    {
        private readonly ISvcDbConnection Connection;
        public SvcCategories(ISvcDbConnection connection)
        {
            Connection = connection;
        }

        #region Procedures Names
        private const string SP_GetCategories = "GetCategories";
        #endregion

        #region Parameters Names
        private const string CategoryId = "id";
        private const string CategoryName = "name";
        #endregion

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                SqlCommand cmd = Connection.OpenDbConnection(SP_GetCategories, CommandType.StoredProcedure);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category() { Id = reader.GetInt32(CategoryId), Name = reader.GetString(CategoryName) };
                    categories.Add(category);
                }
                Connection.CloseDbConnection();
            }
            catch (Exception ex)
            {
                throw;
            }
            return categories;
        }
    }
}
