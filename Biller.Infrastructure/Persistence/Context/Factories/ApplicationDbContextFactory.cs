using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biller.Infrastructure.Persistence.Context.Factories;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("server=localhost,1433;database=Biller;user=sa;password=YourStrongPassw0rd;TrustServerCertificate=true;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

