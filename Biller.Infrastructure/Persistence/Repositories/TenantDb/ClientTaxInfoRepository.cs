using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class ClientTaxInfoRepository : IClientTaxInfoRepository
{
    private readonly TenantDbContext dbContext;

    public ClientTaxInfoRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<ClientTaxInfo>> GetAllByClientIdAsync(int clientId)
    {
        return await dbContext.ClientTaxInfos
            .AsNoTracking()
            .Include(c => c.TaxRegime)
            .Where(c => c.ClientId == clientId)
            .ToListAsync();
    }

    public async Task<ClientTaxInfo?> GetByIdAsync(int id)
    {
        return await dbContext.ClientTaxInfos
            .Include(c => c.TaxRegime)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(ClientTaxInfo clientTaxInfo)
    {
        await dbContext.ClientTaxInfos.AddAsync(clientTaxInfo);
    }

    public async Task UpdateAsync(ClientTaxInfo clientTaxInfo)
    {
        dbContext.ClientTaxInfos.Update(clientTaxInfo);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var clientTaxInfo = await dbContext.ClientTaxInfos.FindAsync(id);
        if (clientTaxInfo is not null)
            dbContext.ClientTaxInfos.Remove(clientTaxInfo);
    }
}
