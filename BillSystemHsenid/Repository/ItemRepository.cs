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

        public async Task<IEnumerable<Items>> GetAllItems()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Items>("SELECT * FROM itemDetails");

            }

        }

        public async Task<int> AddNewItem(Items item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO itemDetails(itemName,quantity,price,amount) VALUES(@ItemName,@Quantity,@Price,@Amount);SELECT CAST(SCOPE_IDENTITY() as int);";



                return await db.QuerySingleAsync<int>(query,item);
            }
        }

        public async Task<IEnumerable<DefineItems>> getAllDefineItems()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<DefineItems>("SELECT * FROM items");

            }

        }
    }
}
