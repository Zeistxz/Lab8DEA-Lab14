using Lab8JosueCastro.Repositories.Interfaces;
using Lab8JosueCastro.Models;

namespace Lab8JosueCastro.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Ejercicio 3: Obtener productos de una orden específica
        public async Task<List<object>> GetProductsByOrderIdAsync(int orderId)
        {
            return await _orderRepository.GetProductsByOrderIdAsync(orderId);
        }

        // Ejercicio 4: Obtener cantidad total de productos por orden
        public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
        {
            return await _orderRepository.GetTotalQuantityByOrderIdAsync(orderId);
        }

        // Ejercicio 6: Obtener pedidos después de una fecha específica
        public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
        {
            return await _orderRepository.GetOrdersAfterDateAsync(date);
        }

        // Ejercicio 8: Obtener el pedido más reciente
        public async Task<Order?> GetLatestOrderAsync()
        {
            return await _orderRepository.GetLatestOrderAsync();
        }

        // Ejercicio 9: Obtener el cliente con mayor número de pedidos
        public async Task<object?> GetTopClientByOrdersAsync()
        {
            return await _orderRepository.GetTopClientByOrdersAsync();
        }

        // Ejercicio 10: Obtener todos los pedidos con nombre de producto y cantidad
        public async Task<List<object>> GetAllOrdersWithDetailsAsync()
        {
            return await _orderRepository.GetAllOrdersWithDetailsAsync();
        }
        
        // Ejercicio 11: Lógica de negocio para obtener productos vendidos a un cliente específico
        public async Task<List<object>> GetProductsByClientAsync(int clientId)
        {
            return await _orderRepository.GetProductsByClientAsync(clientId);
        }
        
        // Ejercicio 12: Lógica de negocio para obtener clientes que han comprado un producto específico
        public async Task<List<object>> GetClientsByProductAsync(int productId)
        {
            return await _orderRepository.GetClientsByProductAsync(productId);
        }


    }
}