using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Domain.Entities.TenantsContext;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.ApplicationDb;

public class TaxRegimeRepository : ITaxRegimeRepository
{
    private readonly ApplicationDbContext dbContext;

    public TaxRegimeRepository(IHttpContextAccessor context)
    {
        dbContext = context.HttpContext.Items["ApplicationDbContext"] as ApplicationDbContext;
    }

    public async Task<IEnumerable<TaxRegime>> GetAllAsync()
    {
        return await dbContext.TaxRegimes.ToListAsync();
    }

    public async Task<TaxRegime?> GetByIdAsync(int id)
    {
        return await dbContext.TaxRegimes.FindAsync(id);
    }
}
