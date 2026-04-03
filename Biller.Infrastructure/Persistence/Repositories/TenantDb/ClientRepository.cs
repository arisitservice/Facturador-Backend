using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Application.Models.Tenant.Clients;
using Biller.Domain.Entities.Tenant;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Shared;
using Biller.Shared.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.TenantDb;

public class ClientRepository : IClientRepository
{
    private readonly TenantDbContext dbContext;

    public ClientRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items[Constants.HttpContextTenantDbContextKey] as TenantDbContext;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        return await dbContext.Clients.AsNoTracking().Select(x => x.CastTo<ClientDTO>()).ToListAsync();
    }


    public async Task<Client?> GetByIdAsync(int id)
    {
        return await dbContext.Clients.FindAsync(id);
    }

    public async Task AddAsync(Client receptor)
    {
        await dbContext.Clients.AddAsync(receptor);
    }

    public async Task UpdateAsync(Client receptor)
    {
        dbContext.Clients.Update(receptor);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var receptor = await dbContext.Clients.FindAsync(id);
        if (receptor is not null)
            dbContext.Clients.Remove(receptor);
    }
}
