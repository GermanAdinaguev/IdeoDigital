using System.ComponentModel.DataAnnotations;

namespace IdeoDigitalApi.Data.Entities
{
    public class DbInvoice
    {
    
        [Key]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
