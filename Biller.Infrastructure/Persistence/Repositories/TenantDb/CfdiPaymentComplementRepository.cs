using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class CfdiPaymentComplementRepository : ICfdiPaymentComplementRepository
{
    private readonly TenantDbContext dbContext;

    public CfdiPaymentComplementRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task AddAsync(CfdiPaymentComplement cfdiPaymentComplement)
    {
        await dbContext.CfdiPaymentComplements.AddAsync(cfdiPaymentComplement);
    }
}
