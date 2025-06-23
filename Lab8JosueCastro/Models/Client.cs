namespace Lab8JosueCastro.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}