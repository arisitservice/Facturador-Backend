using Biller.Domain.Entities.TenantsContext;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories;

public interface ITaxRegimeRepository
{
    Task<IEnumerable<TaxRegime>> GetAllAsync();
    Task<TaxRegime?> GetByIdAsync(int id);
}
