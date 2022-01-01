namespace OrderApi.Order
{
    public class OrderDomain
    {
        public String Id { get; set; }
        public double Amount { get; set; } = 0.0;
        public String Status { get; set; } = "pending";
        public String WalletId { get; set; }
        public String CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
    }
}
