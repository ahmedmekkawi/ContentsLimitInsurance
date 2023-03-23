using ContentsLimitInsurance.Interfaces;
using ContentsLimitInsurance.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ContentsLimitInsurance.Services
{
    public class SvcItems : ISvcItems
    {
        private readonly ISvcDbConnection Connection;
        public SvcItems(ISvcDbConnection connection)
        {
            Connection = connection;
        }

        #region Procedures Names
        private const string SP_GetAllItems = "GetItems";
        private const string SP_DeleteItemById = "DeleteItem";
        private const string SP_AddItem = "AddItem";

        #endregion

        #region Parameters Names
        private const string ItemId = "id";
        private const string ItemName = "name";
        private const string ItemValue = "value";
        private const string ItemCategoryId = "categoryId";
        private const string ItemCategoryName = "categoryName";

        #endregion

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                SqlCommand cmd = Connection.OpenDbConnection(SP_GetAllItems, CommandType.StoredProcedure);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item()
                    {
                        Id = reader.GetInt32(ItemId),
                        Name = reader.GetString(ItemName),
                        Value = reader.GetInt32(ItemValue),
                        Category = new Category()
                        {
                            Id = reader.GetInt32(ItemCategoryId),
                            Name = reader.GetString(ItemCategoryName)
                        }
                    };
                    items.Add(item);
                }
                Connection.CloseDbConnection();
            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

        public void DeleteItem(int itemId)
        {
            try
            {
                SqlCommand cmd = Connection.OpenDbConnection(SP_DeleteItemById, CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue(ItemId, itemId);
                cmd.ExecuteNonQuery();
                Connection.CloseDbConnection();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddItem(Item item)
        {
            try
            {
                SqlCommand cmd = Connection.OpenDbConnection(SP_AddItem, CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue(ItemName, item.Name);
                cmd.Parameters.AddWithValue(ItemValue, item.Value);
                cmd.Parameters.AddWithValue(ItemCategoryId, item.Category?.Id);
                cmd.ExecuteNonQuery();
                Connection.CloseDbConnection();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
