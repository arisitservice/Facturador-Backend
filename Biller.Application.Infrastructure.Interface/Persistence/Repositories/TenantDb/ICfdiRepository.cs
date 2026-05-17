using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ICfdiRepository
{
    Task<Cfdi?> GetByIdAsync(int id);
    Task AddAsync(Cfdi cfdi);
}
