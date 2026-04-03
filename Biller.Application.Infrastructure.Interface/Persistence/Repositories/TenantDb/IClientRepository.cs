using Biller.Application.Models.Tenant.Clients;
using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IClientRepository
{
    Task<Client?> GetByIdAsync(int id);
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task AddAsync(Client receptor);
    Task UpdateAsync(Client receptor);
    Task DeleteAsync(int id);
}
