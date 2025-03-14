using BillSystemHsenid.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BillSystemHsenid.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly string _connectionString;

        public BillRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateBill(Bill bill)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string billQuery = @"INSERT INTO Bills (SubTotal, Discount, Tax, TotalAmount) 
                                     VALUES (@SubTotal, @Discount, @Tax, @TotalAmount);
                                     SELECT CAST(SCOPE_IDENTITY() as int);";

                    int billId = await db.QuerySingleAsync<int>(billQuery, bill);



                    foreach (var item in bill.BillItems)
                    {
                        item.BillId = billId;
                        string billItemQuery = @"INSERT INTO BillItems (BillId, ItemId, Quantity, Price, Amount) 
                                             VALUES (@BillId, @ItemId, @Quantity, @Price, @Amount);";
                        await db.ExecuteAsync(billItemQuery, item);
                    }

                    return billId;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching items from the database", ex);
                }
            }
        }

        public async Task<IEnumerable<Bill>> GetAllBills()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    return await db.QueryAsync<Bill>("SELECT * FROM Bills");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching items from the database", ex);

                }
            }
        }
    }
}
