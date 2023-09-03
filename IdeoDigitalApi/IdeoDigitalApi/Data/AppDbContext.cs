using IdeoDigitalApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdeoDigitalApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<DbInvoice> Invoices { get; set; }

        public DbSet<DbInvoiceItem> Items { get; set; }

        public DbSet<InvoiceItems> InvoiceItems { get; set; }
    }
}
