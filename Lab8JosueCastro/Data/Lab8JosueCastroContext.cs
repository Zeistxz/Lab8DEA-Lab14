using Lab8JosueCastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8JosueCastro.Data
{
    public class Lab8JosueCastroContext : DbContext
    {
        public Lab8JosueCastroContext(DbContextOptions<Lab8JosueCastroContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla Clients
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasKey(e => e.ClientId);
                
                entity.Property(e => e.ClientId).HasColumnName("clientid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Email).HasColumnName("email");
            });

            // Tabla Products
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("productid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Price).HasColumnName("price");
            });

            // Tabla Orders
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("orderid");
                entity.Property(e => e.ClientId).HasColumnName("clientid");
                entity.Property(e => e.ProductId).HasColumnName("productid");
                entity.Property(e => e.OrderDate).HasColumnName("orderdate");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
