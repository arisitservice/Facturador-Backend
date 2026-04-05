using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class TenantUnitOfWork : ITenantUnitOfWork
{
    private readonly TenantDbContext dbContext;

    public IClientRepository Clients { get; }
    public ITaxRegimeRepository TaxRegimes { get; }
    public ITenantUserRepository TenantUsers { get; }
    public ICfdiUseRepository CfdiUses { get; }
    public IMeasurementUnitRepository MeasurementUnits { get; }
    public IProductRepository Products { get; }
    public ICancellationReasonRepository CancellationReasons { get; }
    public ICurrencyRepository Currencies { get; }

    public TenantUnitOfWork(
        IHttpContextAccessor context,
        IClientRepository clientRepository,
        ITaxRegimeRepository taxRegimeRepository,
        ITenantUserRepository tenantUserRepository,
        ICfdiUseRepository cfdiUseRepository,
        IMeasurementUnitRepository measurementUnitRepository,
        IProductRepository productRepository,
        ICancellationReasonRepository cancellationReasonRepository,
        ICurrencyRepository currencyRepository)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
        Clients = clientRepository;
        TaxRegimes = taxRegimeRepository;
        TenantUsers = tenantUserRepository;
        CfdiUses = cfdiUseRepository;
        MeasurementUnits = measurementUnitRepository;
        Products = productRepository;
        CancellationReasons = cancellationReasonRepository;
        Currencies = currencyRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

