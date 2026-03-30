using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;
using Biller.Infrastructure.Persistence.Context;

namespace Biller.Infrastructure.Persistence.Repositories.MainDb;

public class MainUnitOfWork : IMainUnitOfWork
{
    private readonly MainDbContext _context;

    public ITenantRepository Tenants { get; }
    public IUserRepository Users { get; }

    public MainUnitOfWork(MainDbContext context, ITenantRepository tenants, IUserRepository users)
    {
        _context = context;
        Tenants  = tenants;
        Users    = users;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
