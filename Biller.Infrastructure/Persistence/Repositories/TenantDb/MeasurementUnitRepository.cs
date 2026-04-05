using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class MeasurementUnitRepository : IMeasurementUnitRepository
{
    private readonly TenantDbContext dbContext;

    public MeasurementUnitRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<MeasurementUnit>> GetAllAsync()
    {
        return await dbContext.MeasurementUnits.ToListAsync();
    }
}
