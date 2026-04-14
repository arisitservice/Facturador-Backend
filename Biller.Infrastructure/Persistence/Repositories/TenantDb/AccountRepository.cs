using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class AccountRepository : IAccountRepository
{
    private readonly TenantDbContext dbContext;

    public AccountRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await dbContext.Account
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await dbContext.Account.FindAsync(id);
    }

    public async Task AddAsync(Account account)
    {
        await dbContext.Account.AddAsync(account);
    }

    public async Task UpdateAsync(Account account)
    {
        dbContext.Account.Update(account);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var account = await dbContext.Account.FindAsync(id);
        if (account is not null)
            dbContext.Account.Remove(account);
    }
}
