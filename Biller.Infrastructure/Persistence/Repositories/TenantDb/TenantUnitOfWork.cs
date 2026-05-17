using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TenantUnitOfWork : ITenantUnitOfWork
{
    private readonly TenantDbContext dbContext;

    public IAccountRepository Accounts { get; }
    public IClientRepository Clients { get; }
    public ITaxInfoRepository TaxInfos { get; }
    public ITaxRegimeRepository TaxRegimes { get; }
    public ITenantUserRepository TenantUsers { get; }
    public ICfdiUseRepository CfdiUses { get; }
    public IMeasurementUnitRepository MeasurementUnits { get; }
    public IProductRepository Products { get; }
    public ICancellationReasonRepository CancellationReasons { get; }
    public ICurrencyRepository Currencies { get; }
    public ICfdiRepository Cfdis { get; }
    public ICfdiConceptRepository CfdiConcepts { get; }
    public ICfdiPaymentComplementRepository CfdiPaymentComplements { get; }

    public TenantUnitOfWork(
        IHttpContextAccessor context,
        IAccountRepository accountRepository,
        IClientRepository clientRepository,
        ITaxInfoRepository taxInfoRepository,
        ITaxRegimeRepository taxRegimeRepository,
        ITenantUserRepository tenantUserRepository,
        ICfdiUseRepository cfdiUseRepository,
        IMeasurementUnitRepository measurementUnitRepository,
        IProductRepository productRepository,
        ICancellationReasonRepository cancellationReasonRepository,
        ICurrencyRepository currencyRepository,
        ICfdiRepository cfdiRepository,
        ICfdiConceptRepository cfdiConceptRepository,
        ICfdiPaymentComplementRepository cfdiPaymentComplementRepository)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
        Accounts = accountRepository;
        Clients = clientRepository;
        TaxInfos = taxInfoRepository;
        TaxRegimes = taxRegimeRepository;
        TenantUsers = tenantUserRepository;
        CfdiUses = cfdiUseRepository;
        MeasurementUnits = measurementUnitRepository;
        Products = productRepository;
        CancellationReasons = cancellationReasonRepository;
        Currencies = currencyRepository;
        Cfdis = cfdiRepository;
        CfdiConcepts = cfdiConceptRepository;
        CfdiPaymentComplements = cfdiPaymentComplementRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

