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
    private readonly IHttpContextAccessor contextAccessor;

    public ApplicationDbContextGenerator(IHttpContextAccessor httpContextAccessor)
    {
        contextAccessor = httpContextAccessor;
    }

    public ApplicationDbContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
