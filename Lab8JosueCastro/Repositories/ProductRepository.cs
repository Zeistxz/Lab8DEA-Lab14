using Lab8JosueCastro.Data;
using Lab8JosueCastro.Models;
using Lab8JosueCastro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8JosueCastro.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Lab8JosueCastroContext _context;

        public ProductRepository(Lab8JosueCastroContext context)
        {
            _context = context;
        }

        // Ejercicio 2: Usar LINQ para buscar productos con precio mayor al indicado
        public async Task<List<Product>> GetProductsByPriceAsync(decimal price)
        {
            return await _context.Products
                .Where(p => p.Price > price)
                .ToListAsync();
        }

        // Ejercicio 5: Usar LINQ para obtener el producto más caro
        public async Task<Product?> GetMostExpensiveProductAsync()
        {
            return await _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefaultAsync();
        }

        // Ejercicio 7: Usar LINQ para calcular el precio promedio
        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _context.Products
                .AverageAsync(p => p.Price);
        }

        // Ejercicio 8: Usar LINQ para obtener productos sin descripción
        public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
        {
            return await _context.Products
                .Where(p => string.IsNullOrEmpty(p.Description))
                .ToListAsync();
        }
    }
}