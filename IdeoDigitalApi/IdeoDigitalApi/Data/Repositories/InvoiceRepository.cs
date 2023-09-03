using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Data.Interfaces;
using IdeoDigitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeoDigitalApi.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateInvoiceAsync(DbInvoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            _context.Invoices.Add(invoice);

            await _context.SaveChangesAsync();

            return invoice.Id;
        }

        public async Task<DbInvoice> GetInvoiceByIdAsync(int id)
        {

            return await _context.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
        }

        public async Task<IEnumerable<DbInvoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<bool> UpdateInvoiceAsync(DbInvoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }           


            _context.Invoices.Attach(invoice);
            _context.Entry(invoice).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            

            return true;
        }
    }
}
