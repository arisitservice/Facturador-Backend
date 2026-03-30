using Biller.Domain.Entities.TenantsContext;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories;

public interface IClientRepository
{
    Task<Client?> GetByIdAsync(int id);
    Task<IEnumerable<Client>> GetAllAsync();
    Task AddAsync(Client receptor);
    Task UpdateAsync(Client receptor);
    Task DeleteAsync(int id);
}
