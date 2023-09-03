using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Models;

namespace IdeoDigitalApi.Data.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<int> CreateInvoiceAsync(DbInvoice invoice);
        Task<bool> UpdateInvoiceAsync(DbInvoice invoice);
        Task<DbInvoice> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<DbInvoice>> GetInvoicesAsync();
    }
}
