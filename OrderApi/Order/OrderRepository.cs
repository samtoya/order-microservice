using Microsoft.EntityFrameworkCore;

namespace OrderApi.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _dbContext = orderDbContext;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(string id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<Order> CreateOrderFromDto(OrderDto dto)
        {
            var order = Order.FromDto(dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Boolean> DeleteOrderById(string id)
        {
            var order = _dbContext.Orders.FirstOrDefault(order => order.Id == id);
            if (order == null)
            {
                return false;
            }
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

