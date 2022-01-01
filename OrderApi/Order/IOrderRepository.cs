namespace OrderApi.Order
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(String id);
        Task<Order> CreateOrderFromDto(OrderDto dto);
        Task<Boolean> DeleteOrderById(String id);
    }
}