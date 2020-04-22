using AutoMapper;
using Domain;

namespace Application.Customers
{
    public class CustomerDtoMapperProfile : Profile
    {
        public CustomerDtoMapperProfile()
        {
            CreateMap<Studio, StudioDto>();
            CreateMap<Studio, StudioDetailDto>();
        }
    }
}