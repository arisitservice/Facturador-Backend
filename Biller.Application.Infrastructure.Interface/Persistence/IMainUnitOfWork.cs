using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;

namespace Biller.Application.Infrastructure.Interface.Persistence;

public interface IMainUnitOfWork
{
    ITenantRepository Tenants { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
