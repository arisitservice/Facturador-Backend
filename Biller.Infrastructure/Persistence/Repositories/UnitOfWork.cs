using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Infrastructure.Persistence.Contexts;

namespace Biller.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IReceptorRepository Receptores { get; }

    public UnitOfWork(ApplicationDbContext context, IReceptorRepository receptorRepository)
    {
        _context = context;
        Receptores = receptorRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}

