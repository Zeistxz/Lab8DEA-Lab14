using Lab8JosueCastro.Models;

namespace Lab8JosueCastro.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsByNameAsync(string name);
    }
}