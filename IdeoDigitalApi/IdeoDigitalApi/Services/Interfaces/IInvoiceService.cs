using IdeoDigitalApi.Models;

namespace IdeoDigitalApi.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<int> CreateInvoiceAsync(Invoice invoice);
        Task<bool> UpdateInvoiceAsync(Invoice invoice);
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
    }
}
