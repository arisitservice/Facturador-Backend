using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class CfdiConceptRepository : ICfdiConceptRepository
{
    private readonly TenantDbContext dbContext;

    public CfdiConceptRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task AddAsync(CfdiConcept cfdiConcept)
    {
        await dbContext.CfdiConcepts.AddAsync(cfdiConcept);
    }
}
