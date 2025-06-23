using Lab8JosueCastro.Models;
using Lab8JosueCastro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab8JosueCastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // Ejercicio 1: Obtener los Clientes que Tienen un Nombre Específico
        [HttpGet("byname")]
        public async Task<ActionResult<List<Client>>> GetClientsByName([FromQuery] string name)
        {
            var clients = await _clientService.GetClientsByNameAsync(name);
            if (clients == null || !clients.Any())
            {
                return NotFound("No se encontraron clientes con ese nombre.");
            }
            return Ok(clients);
        }
    }
}