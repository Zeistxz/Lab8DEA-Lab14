using Lab8JosueCastro.Models;

namespace Lab8JosueCastro.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<object>> GetProductsByOrderIdAsync(int orderId);
        Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
        Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
        Task<Order?> GetLatestOrderAsync();
        Task<object?> GetTopClientByOrdersAsync();

        // Ejercicio 10: Firma para obtener todos los pedidos con detalles
        Task<List<object>> GetAllOrdersWithDetailsAsync();
        
        // Ejercicio 11: Firma para obtener productos vendidos por cliente
        Task<List<object>> GetProductsByClientAsync(int clientId);
        
        // Ejercicio 12: Firma para obtener clientes que compraron un producto
        Task<List<object>> GetClientsByProductAsync(int productId);


    }
    
}