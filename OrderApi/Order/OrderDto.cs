namespace OrderApi.Order
{
    public class OrderDto
    {
        public double Amount { get; set; }
        public String Status { get; set; } = "pending";
        public String WalletId { get; set; }
        public String CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
