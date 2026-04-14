using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(int id);
    Task<IEnumerable<Account>> GetAllAsync();
    Task AddAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(int id);
}
