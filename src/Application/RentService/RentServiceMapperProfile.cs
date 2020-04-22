using AutoMapper;
using Domain;

namespace Application.RentService
{
    public class RentServiceMapperProfile : Profile
    {
        public RentServiceMapperProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}