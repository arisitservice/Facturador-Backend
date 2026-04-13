using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IAccountTaxInfoRepository
{
    Task<AccountTaxInfo?> GetByIdAsync(int id);
    Task<IEnumerable<AccountTaxInfo>> GetAllAsync();
    Task AddAsync(AccountTaxInfo accountTaxInfo);
    Task UpdateAsync(AccountTaxInfo accountTaxInfo);
    Task DeleteAsync(int id);
}
