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

    public TenantUnitOfWork(IHttpContextAccessor context, IClientRepository receptorRepository, ITaxRegimeRepository taxRegimeRepository)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
        Receptores = receptorRepository;
        TaxRegimes = taxRegimeRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

