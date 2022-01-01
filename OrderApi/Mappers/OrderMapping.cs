using AutoMapper;
using OrderApi.Order;

namespace OrderApi.Mappers;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order.Order, OrderDomain>().ReverseMap();
    }
}