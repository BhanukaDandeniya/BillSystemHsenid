using BillSystemHsenid.Models;

namespace BillSystemHsenid.Repository
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Items>> GetAllItems();

        public Task<int> AddNewItem(Items item);

        public Task<IEnumerable<DefineItems>> getAllDefineItems();


    }
}
