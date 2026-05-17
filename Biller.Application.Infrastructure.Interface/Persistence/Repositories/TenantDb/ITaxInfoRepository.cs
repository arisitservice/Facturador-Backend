using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ITaxInfoRepository
{
    Task<TaxInfo?> GetByIdAsync(int id);
    Task<IEnumerable<TaxInfo>> GetAllAsync();
    Task<IEnumerable<TaxInfo>> GetAllByClientIdAsync(int clientId);
    Task<bool> ExistsAsync(int id);
    Task AddAsync(TaxInfo taxInfo);
    Task UpdateAsync(TaxInfo taxInfo);
    Task DeleteAsync(int id);
}
