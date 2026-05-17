using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TaxInfoRepository : ITaxInfoRepository
{
    private readonly TenantDbContext dbContext;

    public TaxInfoRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<TaxInfo>> GetAllAsync()
    {
        return await dbContext.TaxInfos
            .AsNoTracking()
            .Include(t => t.TaxRegime)
            .Where(t => t.Type == TaxInfoType.Account)
            .ToListAsync();
    }

    public async Task<IEnumerable<TaxInfo>> GetAllByClientIdAsync(int clientId)
    {
        return await dbContext.TaxInfos
            .AsNoTracking()
            .Include(t => t.TaxRegime)
            .Where(t => t.Type == TaxInfoType.Client && t.ClientId == clientId)
            .ToListAsync();
    }

    public async Task<TaxInfo?> GetByIdAsync(int id)
    {
        return await dbContext.TaxInfos
            .Include(t => t.TaxRegime)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await dbContext.TaxInfos.AnyAsync(t => t.Id == id);
    }

    public async Task AddAsync(TaxInfo taxInfo)
    {
        await dbContext.TaxInfos.AddAsync(taxInfo);
    }

    public async Task UpdateAsync(TaxInfo taxInfo)
    {
        dbContext.TaxInfos.Update(taxInfo);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var taxInfo = await dbContext.TaxInfos.FindAsync(id);
        if (taxInfo is not null)
            dbContext.TaxInfos.Remove(taxInfo);
    }
}
