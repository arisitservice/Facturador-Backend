using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}
