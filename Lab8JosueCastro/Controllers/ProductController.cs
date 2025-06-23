using Lab8JosueCastro.Models;
using Lab8JosueCastro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8JosueCastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Ejercicio 2: Obtener productos cuyo precio sea mayor a un valor específico
        [HttpGet("byprice")]
        public async Task<ActionResult<List<Product>>> GetProductsByPrice([FromQuery] decimal price)
        {
            var products = await _productService.GetProductsByPriceAsync(price);
            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos con precio mayor al valor indicado.");
            }
            return Ok(products);
        }

        // Ejercicio 5: Obtener el producto más caro
        [HttpGet("most-expensive")]
        public async Task<ActionResult<Product>> GetMostExpensiveProduct()
        {
            var product = await _productService.GetMostExpensiveProductAsync();
            if (product == null)
            {
                return NotFound("No se encontró ningún producto.");
            }
            return Ok(product);
        }

        // Ejercicio 7: Obtener el precio promedio de todos los productos
        [HttpGet("average-price")]
        public async Task<IActionResult> GetAveragePrice()
        {
            var averagePrice = await _productService.GetAveragePriceAsync();
            return Ok(new { AveragePrice = averagePrice });
        }

        // Ejercicio 8: Obtener productos sin descripción
        [HttpGet("without-description")]
        public async Task<ActionResult<List<Product>>> GetProductsWithoutDescription()
        {
            var products = await _productService.GetProductsWithoutDescriptionAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos sin descripción.");
            }
            return Ok(products);
        }
    }
}
