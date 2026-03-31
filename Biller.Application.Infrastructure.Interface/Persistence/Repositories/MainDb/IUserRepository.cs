using Biller.Domain.Entities.Main;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllByTenantAsync(Guid tenantId);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
