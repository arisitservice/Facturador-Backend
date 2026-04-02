using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ITenantUserRepository
{
    Task<TenantUser?> GetByEmailAsync(string email);
    Task AddAsync(TenantUser user);
}
