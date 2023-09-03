using System.ComponentModel.DataAnnotations;

namespace IdeoDigitalApi.Data.Entities
{
    public class InvoiceItems
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
    }
}
