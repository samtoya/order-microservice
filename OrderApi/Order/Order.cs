namespace OrderApi.Order
{
    public class Order
    {
        public String Id { get; set; }
        public String CustomerId { get; set; }
        public double Total { get; set; } = 0.0;
        public String Status { get; set; } = "pending";
        public String WalletId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Quantity { get; set; }

        public static Order FromDto(OrderDto dto)
        {
            return new Order
            {
                Id = Guid.NewGuid().ToString(),
                Quantity = dto.Quantity,
                Status = dto.Status,
                Total = 0.0,
                CustomerId = dto.CustomerId,
                WalletId = dto.WalletId
            };
        }
    }
}
