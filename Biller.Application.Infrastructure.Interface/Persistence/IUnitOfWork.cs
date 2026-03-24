using Biller.Application.Infrastructure.Interface.Persistence.Repositories;

namespace Biller.Application.Infrastructure.Interface.Persistence;

public interface IUnitOfWork
{
    IReceptorRepository Receptores { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
