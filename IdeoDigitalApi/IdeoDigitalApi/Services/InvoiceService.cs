using AutoMapper;
using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Data.Interfaces;
using IdeoDigitalApi.Models;
using IdeoDigitalApi.Services.Interfaces;
using System.Net;

namespace IdeoDigitalApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IInvoiceItemsRepository _invoiceItemsRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IMapper mapper,
            IInvoiceRepository invoiceRepository,
            IItemRepository itemRepository,
            IInvoiceItemsRepository invoiceItemsRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
            _invoiceItemsRepository = invoiceItemsRepository;
        }

        public async Task<int> CreateInvoiceAsync(Invoice invoice)
        {
            int invoiceId = 0;

            try
            {
                var newInvoice = _mapper.Map<DbInvoice>(invoice);
                var invoiceItems = _mapper.Map<List<DbInvoiceItem>>(invoice.InvoiceItems);

                var itemsIds = new List<int>();
                foreach (var item in invoiceItems)
                {
                    itemsIds.Add(await CreateInvoiceItem(item));
                }

                CalculateTaxesAndTotalSum(newInvoice, invoiceItems);
                invoiceId = await _invoiceRepository.CreateInvoiceAsync(newInvoice);
                AddItemsToInvoices(itemsIds, invoiceId);

                return invoiceId;
            }
            catch (Exception ex)
            {
                //Add logs
            }    
            
            return 0;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            try
            {
                var existInvoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
                var resultInvoice = _mapper.Map<Invoice>(existInvoice);

                var itemsIds = await GetItemsIDsByInvoiceIdAsync(id);
                var items = new List<InvoiceItem>();
                foreach (var itemId in itemsIds)
                {
                    var item = await _itemRepository.GetItemByIdAsync(itemId);
                    items.Add(_mapper.Map<InvoiceItem>(item));
                }

                resultInvoice.InvoiceItems = items;

                return resultInvoice;
            }
            catch (Exception ex)
            {
                //Add logs
            }

            return new Invoice();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            try
            {
                var invoices = await _invoiceRepository.GetInvoicesAsync();
                return _mapper.Map<List<Invoice>>(invoices);
            }
            catch (Exception ex)
            {
                //Add logs
            }

            return new List<Invoice>();
        }

        public async Task<bool> UpdateInvoiceAsync(Invoice invoice)
        {
            try
            {               
                var currentInvoice = _mapper.Map<DbInvoice>(invoice);
                var invoiceItems = _mapper.Map<List<DbInvoiceItem>>(invoice.InvoiceItems);

                var itemsIds = new List<int>();
                foreach (var item in invoiceItems)
                {                 
                    if (item.Id > 0)
                    {                        
                        await _itemRepository.UpdateItemAsync(item);
                    }
                    else
                    {
                        itemsIds.Add(await CreateInvoiceItem(item));
                    }
                }

                
                CalculateTaxesAndTotalSum(currentInvoice, invoiceItems);
                AddItemsToInvoices(itemsIds, invoice.Id);

                return await _invoiceRepository.UpdateInvoiceAsync(currentInvoice);
            }
            catch(Exception ex)
            {
                //Add logs
            }

            return false;
        }

        private async Task<IEnumerable<int>> GetItemsIDsByInvoiceIdAsync(int invoiceId)
        {
            return await _invoiceItemsRepository.GetInvoiceItemsIdsAsync(invoiceId);
        }


        private void CalculateTaxesAndTotalSum(DbInvoice invoice,List<DbInvoiceItem> invoiceItems)
        {
            var totalSum = invoiceItems.Sum(x => x.TotalPrice);

            invoice.Subtotal = totalSum;
            invoice.Tax = 18;
            invoice.Total = totalSum + (totalSum * invoice.Tax / 100);
        }

        private void AddItemsToInvoices(List<int> itemsIds,int invoiceId)
        {
            itemsIds.ForEach(async id =>
            {
                await _invoiceItemsRepository.CreatInvoiceItemsAsync(new InvoiceItems()
                {
                    InvoiceId = invoiceId,
                    ItemId = id
                });
            });
        }

        private async Task<int> CreateInvoiceItem(DbInvoiceItem item)
        {
            item.TotalPrice = item.PricePerUnit * item.Quantity;
            return await _itemRepository.CreateItemAsync(item);
        } 
    }
}
