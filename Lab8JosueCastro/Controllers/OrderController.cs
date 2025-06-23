using Lab8JosueCastro.Models;
using Lab8JosueCastro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8JosueCastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // Ejercicio 3: Obtener el Detalle de los Productos en una Orden específica
        [HttpGet("products-by-order")]
        public async Task<IActionResult> GetProductsByOrderId([FromQuery] int orderId)
        {
            var result = await _orderService.GetProductsByOrderIdAsync(orderId);
            if (result == null || !result.Any())
            {
                return NotFound($"No se encontraron productos para la orden {orderId}.");
            }
            return Ok(result);
        }

        // Ejercicio 4: Obtener la Cantidad Total de Productos en una Orden específica
        [HttpGet("total-quantity-by-order")]
        public async Task<IActionResult> GetTotalQuantityByOrderId([FromQuery] int orderId)
        {
            var totalQuantity = await _orderService.GetTotalQuantityByOrderIdAsync(orderId);
            return Ok(new { OrderId = orderId, TotalQuantity = totalQuantity });
        }

        // Ejercicio 6: Obtener pedidos realizados después de una fecha específica
        [HttpGet("orders-after-date")]
        public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
        {
            var orders = await _orderService.GetOrdersAfterDateAsync(date);
            if (orders == null || !orders.Any())
            {
                return NotFound($"No se encontraron pedidos después de la fecha {date.ToShortDateString()}.");
            }
            return Ok(orders);
        }

        // Ejercicio 8: Obtener el pedido más reciente
        [HttpGet("latest-order")]
        public async Task<ActionResult<Order>> GetLatestOrder()
        {
            var latestOrder = await _orderService.GetLatestOrderAsync();
            if (latestOrder == null)
            {
                return NotFound("No se encontró ningún pedido.");
            }
            return Ok(latestOrder);
        }

        // Ejercicio 9: Obtener el cliente con mayor número de pedidos
        [HttpGet("top-client-by-orders")]
        public async Task<IActionResult> GetTopClientByOrders()
        {
            var topClient = await _orderService.GetTopClientByOrdersAsync();
            if (topClient == null)
            {
                return NotFound("No se encontraron pedidos para calcular el cliente top.");
            }
            return Ok(topClient);
        }

        // Ejercicio 10: Obtener todos los pedidos y sus detalles (producto y cantidad)
        [HttpGet("all-orders-with-details")]
        public async Task<IActionResult> GetAllOrdersWithDetails()
        {
            var orders = await _orderService.GetAllOrdersWithDetailsAsync();
            if (orders == null || !orders.Any())
            {
                return NotFound("No se encontraron pedidos.");
            }
            return Ok(orders);
        }
        
        // Ejercicio 11: Obtener todos los productos vendidos a un cliente específico
        [HttpGet("products-by-client")]
        public async Task<IActionResult> GetProductsByClient([FromQuery] int clientId)
        {
            var products = await _orderService.GetProductsByClientAsync(clientId);
            if (products == null || !products.Any())
            {
                return NotFound($"No se encontraron productos vendidos al cliente {clientId}.");
            }
            return Ok(products);
        }
        
        // Ejercicio 12: Obtener todos los clientes que compraron un producto específico
        [HttpGet("clients-by-product")]
        public async Task<IActionResult> GetClientsByProduct([FromQuery] int productId)
        {
            var clients = await _orderService.GetClientsByProductAsync(productId);
            if (clients == null || !clients.Any())
            {
                return NotFound($"No se encontraron clientes que hayan comprado el producto {productId}.");
            }
            return Ok(clients);
        }


    }
}
