using Microsoft.EntityFrameworkCore;

namespace OrderApi.Order
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
