namespace Lab8JosueCastro.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public Client Client { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}