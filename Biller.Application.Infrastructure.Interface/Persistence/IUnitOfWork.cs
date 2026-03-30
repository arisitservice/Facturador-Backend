using Biller.Application.Infrastructure.Interface.Persistence.Repositories;

namespace Biller.Application.Infrastructure.Interface.Persistence;

public interface IUnitOfWork
{
    IClientRepository Receptores { get; }
    ITaxRegimeRepository TaxRegimes { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
