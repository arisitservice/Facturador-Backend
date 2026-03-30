using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biller.Infrastructure.Persistence.Context.Factories;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=172.17.0.1;Port=5432;Database=Biller;Username=postgres;Password=YourStrongPassw0rd;SSL Mode=Disable");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

