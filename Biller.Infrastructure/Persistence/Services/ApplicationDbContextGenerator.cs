using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Services;

public interface IApplicationDbContextGenerator
{
    ApplicationDbContext CreateDbContext(string connectionString);
}

public class ApplicationDbContextGenerator : IApplicationDbContextGenerator
{

    public ApplicationDbContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
