using System.ComponentModel.DataAnnotations;

namespace IdeoDigitalApi.Data.Entities
{
    public class DbInvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
