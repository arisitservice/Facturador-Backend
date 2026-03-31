
using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Services;

public interface ITenantDbService
{
    public Task Create(string connectionString, TenantUser owner);
}
