using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.ApplicationDb;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext dbContext;

    public IClientRepository Receptores { get; }
    public ITaxRegimeRepository TaxRegimes { get; }

    public UnitOfWork(IHttpContextAccessor context, IClientRepository receptorRepository, ITaxRegimeRepository taxRegimeRepository)
    {
        dbContext = context.HttpContext.Items["ApplicationDbContext"] as ApplicationDbContext;
        Receptores = receptorRepository;
        TaxRegimes = taxRegimeRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

