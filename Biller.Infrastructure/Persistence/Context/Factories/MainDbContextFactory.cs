using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Biller.Infrastructure.Persistence.Context.Factories;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        //var connectionString = configuration.GetConnectionString("MainDb");

        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        optionsBuilder.UseSqlServer("server=localhost,1433;database=Biller;user=sa;password=YourStrongPassw0rd;TrustServerCertificate=true;");

        return new MainDbContext(optionsBuilder.Options);
    }
}
