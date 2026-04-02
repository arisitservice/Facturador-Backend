using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TenantUnitOfWork : ITenantUnitOfWork
{
    private readonly TenantDbContext dbContext;

    public IClientRepository Receptores { get; }
    public ITaxRegimeRepository TaxRegimes { get; }
    public ITenantUserRepository TenantUsers { get; }

    public TenantUnitOfWork(IHttpContextAccessor context, IClientRepository receptorRepository, ITaxRegimeRepository taxRegimeRepository, ITenantUserRepository tenantUserRepository)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
        Receptores = receptorRepository;
        TaxRegimes = taxRegimeRepository;
        TenantUsers = tenantUserRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

