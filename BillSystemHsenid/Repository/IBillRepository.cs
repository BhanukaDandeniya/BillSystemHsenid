using BillSystemHsenid.Models;

namespace BillSystemHsenid.Repository
{
    public interface IBillRepository
    {
        Task<int> CreateBill(Bill bill);
        Task<IEnumerable<Bill>> GetAllBills();
    }
}
