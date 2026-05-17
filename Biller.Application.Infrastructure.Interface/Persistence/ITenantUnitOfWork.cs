using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

namespace Biller.Application.Infrastructure.Interface.Persistence;

public interface ITenantUnitOfWork
{
    IAccountRepository Accounts { get; }
    IClientRepository Clients { get; }
    ITaxInfoRepository TaxInfos { get; }
    ITaxRegimeRepository TaxRegimes { get; }
    ITenantUserRepository TenantUsers { get; }
    ICfdiUseRepository CfdiUses { get; }
    IMeasurementUnitRepository MeasurementUnits { get; }
    IProductRepository Products { get; }
    ICancellationReasonRepository CancellationReasons { get; }
    ICurrencyRepository Currencies { get; }
    ICfdiRepository Cfdis { get; }
    ICfdiConceptRepository CfdiConcepts { get; }
    ICfdiPaymentComplementRepository CfdiPaymentComplements { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
