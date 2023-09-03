namespace IdeoDigitalApi.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
