using IdeoDigitalApi.Data.Entities;

namespace IdeoDigitalApi.Data.Interfaces
{
    public interface IInvoiceItemsRepository
    {
        Task CreatInvoiceItemsAsync(InvoiceItems invoiceItem);
        Task<IEnumerable<int>> GetInvoiceItemsIdsAsync(int invoiceId);
    }
}
