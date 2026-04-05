using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IMeasurementUnitRepository
{
    Task<IEnumerable<MeasurementUnit>> GetAllAsync();
}
