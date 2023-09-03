using AutoMapper;
using IdeoDigitalApi.Data.Entities;
using IdeoDigitalApi.Models;

namespace IdeoDigitalApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Invoice,DbInvoice>();
            CreateMap<InvoiceItem, DbInvoiceItem>();

            CreateMap<DbInvoice, Invoice>();
            CreateMap<DbInvoiceItem, InvoiceItem>();
        }
    }
}
