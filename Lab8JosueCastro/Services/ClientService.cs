using Lab8JosueCastro.Models;
using Lab8JosueCastro.Repositories.Interfaces;

namespace Lab8JosueCastro.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // Ejercicio 1: Lógica de negocio para buscar clientes por nombre
        public async Task<List<Client>> GetClientsByNameAsync(string name)
        {
            return await _clientRepository.GetClientsByNameAsync(name);
        }
    }
}