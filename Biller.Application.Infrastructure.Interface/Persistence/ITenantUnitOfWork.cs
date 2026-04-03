using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

namespace Biller.Application.Infrastructure.Interface.Persistence;

public interface ITenantUnitOfWork
{
    IClientRepository Clients { get; }
    ITaxRegimeRepository TaxRegimes { get; }
    ITenantUserRepository TenantUsers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
