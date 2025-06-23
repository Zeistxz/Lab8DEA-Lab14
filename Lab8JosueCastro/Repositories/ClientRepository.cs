using Lab8JosueCastro.Data;
using Lab8JosueCastro.Models;
using Lab8JosueCastro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8JosueCastro.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Lab8JosueCastroContext _context;

        public ClientRepository(Lab8JosueCastroContext context)
        {
            _context = context;
        }

        // Ejercicio 1: Usar LINQ para buscar clientes cuyo nombre contenga un valor
        public async Task<List<Client>> GetClientsByNameAsync(string name)
        {
            return await _context.Clients
                .Where(c => c.Name.Contains(name))
                .ToListAsync(); 
        }
    }
}