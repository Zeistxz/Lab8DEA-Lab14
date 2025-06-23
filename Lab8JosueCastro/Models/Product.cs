namespace Lab8JosueCastro.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}