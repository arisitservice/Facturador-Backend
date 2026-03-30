using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;
using Biller.Domain.Entities.MainDb;
using Biller.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.MainDb;

public class TenantRepository : ITenantRepository
{
    private readonly MainDbContext _context;

    public TenantRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<Tenant?> GetByIdAsync(Guid id)
    {
        return await _context.Tenants.FindAsync(id);
    }

    public async Task<IEnumerable<Tenant>> GetAllAsync()
    {
        return await _context.Tenants.ToListAsync();
    }

    public async Task AddAsync(Tenant tenant)
    {
        await _context.Tenants.AddAsync(tenant);
    }

    public async Task UpdateAsync(Tenant tenant)
    {
        _context.Tenants.Update(tenant);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var tenant = await _context.Tenants.FindAsync(id);
        if (tenant is not null)
            _context.Tenants.Remove(tenant);
    }
}
