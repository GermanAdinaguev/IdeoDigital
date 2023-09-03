using IdeoDigitalApi.Data.Entities;

namespace IdeoDigitalApi.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<int> CreateItemAsync(DbInvoiceItem item);
        Task<bool> UpdateItemAsync(DbInvoiceItem item);
        Task<DbInvoiceItem> GetItemByIdAsync(int id);
        Task<IEnumerable<DbInvoiceItem>> GetItemsAsync(List<int> itemdIds);
    }
}
