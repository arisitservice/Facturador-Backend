using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class AccountTaxInfoRepository : IAccountTaxInfoRepository
{
    private readonly TenantDbContext dbContext;

    public AccountTaxInfoRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<AccountTaxInfo>> GetAllAsync()
    {
        return await dbContext.AccountTaxInfos
            .AsNoTracking()
            .Include(a => a.TaxRegime)
            .ToListAsync();
    }

    public async Task<AccountTaxInfo?> GetByIdAsync(int id)
    {
        return await dbContext.AccountTaxInfos
            .Include(a => a.TaxRegime)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(AccountTaxInfo accountTaxInfo)
    {
        await dbContext.AccountTaxInfos.AddAsync(accountTaxInfo);
    }

    public async Task UpdateAsync(AccountTaxInfo accountTaxInfo)
    {
        dbContext.AccountTaxInfos.Update(accountTaxInfo);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var accountTaxInfo = await dbContext.AccountTaxInfos.FindAsync(id);
        if (accountTaxInfo is not null)
            dbContext.AccountTaxInfos.Remove(accountTaxInfo);
    }
}
