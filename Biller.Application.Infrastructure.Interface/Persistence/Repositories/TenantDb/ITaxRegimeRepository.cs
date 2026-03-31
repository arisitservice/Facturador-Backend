susing Biller.Domain.Entities.TenantsContext;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ITaxRegimeRepository
{
    Task<IEnumerable<TaxRegime>> GetAllAsync();
    Task<TaxRegime?> GetByIdAsync(int id);
}
