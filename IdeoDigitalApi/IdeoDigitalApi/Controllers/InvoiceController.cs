using IdeoDigitalApi.Models;
using IdeoDigitalApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdeoDigitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger,IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpGet,Route("GetInvoices")]
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _invoiceService.GetInvoicesAsync();
        }

        [HttpGet, Route("GetInvoiceById")]
        public async Task<Invoice> GetInvoiceById(int id)
        {
            return  await _invoiceService.GetInvoiceByIdAsync(id);
        }

        [HttpPost, Route("CreateInvoice")]
        public async Task<int> CreateInvoice(Invoice invoice)
        {
            return await _invoiceService.CreateInvoiceAsync(invoice);
        }

        [HttpPost, Route("UpdateInvoice")]
        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            return await _invoiceService.UpdateInvoiceAsync(invoice); 
        }
    }
}