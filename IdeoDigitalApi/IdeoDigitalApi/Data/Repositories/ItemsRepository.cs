using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IdeoDigitalApi.Data.Repositories
{
    public class ItemsRepository : IItemRepository
    {

        private readonly AppDbContext _context;

        public ItemsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateItemAsync(DbInvoiceItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);

            await _context.SaveChangesAsync();

            return item.Id;
        }

        public async Task<DbInvoiceItem> GetItemByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(invoice => invoice.Id == id);
        }

        public async Task<IEnumerable<DbInvoiceItem>> GetItemsAsync(List<int> itemdIds)
        {
            return await _context.Items.Where(x=>itemdIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(DbInvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                throw new ArgumentNullException(nameof(invoiceItem));
            }

            _context.Items.Attach(invoiceItem);
            _context.Entry(invoiceItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
