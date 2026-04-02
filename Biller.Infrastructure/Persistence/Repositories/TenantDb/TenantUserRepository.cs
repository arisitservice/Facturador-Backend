using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TenantUserRepository : ITenantUserRepository
{
    private readonly TenantDbContext dbContext;

    public TenantUserRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<TenantUser?> GetByEmailAsync(string email)
    {
        return await dbContext.TenantUsers.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(TenantUser user)
    {
        await dbContext.TenantUsers.AddAsync(user);
    }
}
