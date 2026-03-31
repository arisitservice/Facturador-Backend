using Biller.Domain.Entities.Main;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;

public interface ITenantRepository
{
    Task<Tenant?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tenant>> GetAllAsync();
    Task AddAsync(Tenant tenant);
    Task UpdateAsync(Tenant tenant);
    Task DeleteAsync(Guid id);
}
