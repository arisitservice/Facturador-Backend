using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class CfdiRepository : ICfdiRepository
{
    private readonly TenantDbContext dbContext;

    public CfdiRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<Cfdi?> GetByIdAsync(int id)
    {
        return await dbContext.Cfdis
            .Include(c => c.Issuer)
                .ThenInclude(i => i.TaxRegime)
            .Include(c => c.Receiver)
                .ThenInclude(r => r.TaxRegime)
            .Include(c => c.CfdiUse)
            .Include(c => c.Currency)
            .Include(c => c.CfdiConcepts)
                .ThenInclude(cc => cc.MeasurementUnit)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Cfdi cfdi)
    {
        await dbContext.Cfdis.AddAsync(cfdi);
    }
}
