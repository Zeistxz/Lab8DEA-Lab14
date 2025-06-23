using Lab8JosueCastro.Data;
using Lab8JosueCastro.Models;
using Lab8JosueCastro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8JosueCastro.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Lab8JosueCastroContext _context;

        public OrderRepository(Lab8JosueCastroContext context)
        {
            _context = context;
        }

        // Ejercicio 3: Productos en una orden
        public async Task<List<object>> GetProductsByOrderIdAsync(int orderId)
        {
            var result = await _context.Orders
                .Where(o => o.OrderId == orderId)
                .Include(o => o.Product)
                .Select(o => new
                {
                    ProductName = o.Product.Name,
                    Quantity = o.Quantity
                })
                .ToListAsync();

            return result.Cast<object>().ToList();
        }

        // Ejercicio 4: Total de productos en una orden
        public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
        {
            return await _context.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => o.Quantity)
                .SumAsync();
        }

        // Ejercicio 6: Pedidos después de una fecha
        public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
        {
            var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            return await _context.Orders
                .Where(o => o.OrderDate > utcDate)
                .ToListAsync();
        }

        // Ejercicio 8: Pedido más reciente
        public async Task<Order?> GetLatestOrderAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();
        }

        // Ejercicio 9: Cliente con más pedidos
        public async Task<object?> GetTopClientByOrdersAsync()
        {
            var topClient = await _context.Orders
                .GroupBy(o => o.ClientId)
                .Select(g => new
                {
                    ClientId = g.Key,
                    TotalOrders = g.Count()
                })
                .OrderByDescending(g => g.TotalOrders)
                .FirstOrDefaultAsync();

            return topClient;
        }

        // Ejercicio 10: Obtener todos los pedidos con nombre de producto y cantidad
        public async Task<List<object>> GetAllOrdersWithDetailsAsync()
        {
            var result = await _context.Orders
                .Include(o => o.Product)
                .Select(o => new
                {
                    ProductName = o.Product.Name,
                    Quantity = o.Quantity
                })
                .ToListAsync();

            return result.Cast<object>().ToList();
        }
        
        // Ejercicio 11: Usar LINQ para obtener productos vendidos a un cliente específico
        public async Task<List<object>> GetProductsByClientAsync(int clientId)
        {
            var result = await _context.Orders
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Product)
                .Select(o => new
                {
                    ProductName = o.Product.Name
                })
                .ToListAsync();

            return result.Cast<object>().ToList();
        }
        
        // Ejercicio 12: Usar LINQ para obtener clientes que han comprado un producto específico
        public async Task<List<object>> GetClientsByProductAsync(int productId)
        {
            var result = await _context.Orders
                .Where(o => o.ProductId == productId)
                .Include(o => o.Client)
                .Select(o => new
                {
                    ClientName = o.Client.Name
                })
                .ToListAsync();

            return result.Cast<object>().ToList();
        }


    }
}
