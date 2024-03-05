using AutoMapper;
using GeekShopping.Email.Domain.Dto;
using GeekShopping.Email.Domain.Entities;

namespace GeekShopping.Email.Infra.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            //CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
            //CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            

        }
    }
}
