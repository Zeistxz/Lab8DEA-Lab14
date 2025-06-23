using Lab8JosueCastro.Models;

namespace Lab8JosueCastro.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByPriceAsync(decimal price);
        Task<Product?> GetMostExpensiveProductAsync();
        Task<decimal> GetAveragePriceAsync();

        // Ejercicio 8: Firma para obtener productos sin descripción
        Task<List<Product>> GetProductsWithoutDescriptionAsync();
    }
}