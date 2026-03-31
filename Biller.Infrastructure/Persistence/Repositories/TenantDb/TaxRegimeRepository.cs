using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TaxRegimeRepository : ITaxRegimeRepository
{
    private readonly TenantDbContext dbContext;

    public TaxRegimeRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<TaxRegime>> GetAllAsync()
    {
        return await dbContext.TaxRegimes.ToListAsync();
    }

    public async Task<TaxRegime?> GetByIdAsync(int id)
    {
        return await dbContext.TaxRegimes.FindAsync(id);
    }
}
