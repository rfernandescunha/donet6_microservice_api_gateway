using AutoMapper;
using GeekShopping.Email.Domain.Dto;
using GeekShopping.Email.Domain.Entities;

namespace GeekShopping.Email.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //CreateMap<OrderHeaderDto, OrderHeader>().ReverseMap();
            //CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
