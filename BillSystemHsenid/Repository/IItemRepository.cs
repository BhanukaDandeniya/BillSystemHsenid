using BillSystemHsenid.Models;

namespace BillSystemHsenid.Repository
{
    public interface IItemRepository
    {
        public Task<IEnumerable<DefineItems>> GetAllItems();

        public Task<int> AddNewItem(DefineItems item);


        

    }
}
