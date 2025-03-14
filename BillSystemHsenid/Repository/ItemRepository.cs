using BillSystemHsenid.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BillSystemHsenid.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<DefineItems>> GetAllItems()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    return await db.QueryAsync<DefineItems>("SELECT * FROM Items WHERE AvailableQuantity > 0 ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching items from the database", ex);

                }
            }
        }

        public async Task<int> AddNewItem(DefineItems item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"INSERT INTO Items (ItemName, Price,AvailableQuantity) 
                                 VALUES (@ItemName, @Price,@AvailableQuantity);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";

                    return await db.QuerySingleAsync<int>(query, item);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching items from the database", ex);

                }
            }
        }
    }
}
