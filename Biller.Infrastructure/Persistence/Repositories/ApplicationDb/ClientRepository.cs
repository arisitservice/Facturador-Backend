using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Domain.Entities.TenantsContext;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.ApplicationDb;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext dbContext;

    public ClientRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items["ApplicationDbContext"] as ApplicationDbContext;
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await dbContext.Clients.FindAsync(id);
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await dbContext.Clients.ToListAsync();
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
