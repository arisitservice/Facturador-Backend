using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Services;

public interface ITenantDbContextGenerator
{
    TenantDbContext CreateDbContext(string connectionString);
}

public class TenantDbContextGenerator : ITenantDbContextGenerator
{

    public TenantDbContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new TenantDbContext(optionsBuilder.Options);
    }
}
