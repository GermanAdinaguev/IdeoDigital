using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Data.Interfaces;
using IdeoDigitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeoDigitalApi.Data.Repositories
{
    public class InvoicesItemsRepository : IInvoiceItemsRepository
    {

        private readonly AppDbContext _context;

        public InvoicesItemsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreatInvoiceItemsAsync(InvoiceItems invoiceItem)
        {
            
            _context.InvoiceItems.Add(invoiceItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> GetInvoiceItemsIdsAsync(int invoiceId)
        {
           return await _context.InvoiceItems.Where(x => x.InvoiceId == invoiceId).Select(x=>x.ItemId).ToListAsync();
        }
    }
}
