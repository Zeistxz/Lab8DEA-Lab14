using Lab8JosueCastro.Models;
using Lab8JosueCastro.Repositories.Interfaces;

namespace Lab8JosueCastro.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Ejercicio 2: Lógica de negocio para buscar productos por precio mayor
        public async Task<List<Product>> GetProductsByPriceAsync(decimal price)
        {
            return await _productRepository.GetProductsByPriceAsync(price);
        }

        // Ejercicio 5: Lógica de negocio para obtener el producto más caro
        public async Task<Product?> GetMostExpensiveProductAsync()
        {
            return await _productRepository.GetMostExpensiveProductAsync();
        }

        // Ejercicio 7: Lógica de negocio para obtener el precio promedio
        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _productRepository.GetAveragePriceAsync();
        }

        // Ejercicio 8: Lógica de negocio para obtener productos sin descripción
        public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
        {
            return await _productRepository.GetProductsWithoutDescriptionAsync();
        }
    }
}