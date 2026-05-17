using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biller.Infrastructure.Persistence.Context.Factories;

public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Biller;Username=postgres;Password=YourStrongPassw0rd;SSL Mode=Disable");

        return new TenantDbContext(optionsBuilder.Options);
    }
}

