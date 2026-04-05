
using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Domain.Entities.Main;
using Biller.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Biller.Infrastructure.Persistence.Seeders;

public class MainDbSeeder
{
    IServiceProvider serviceProvider;
    public MainDbSeeder(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task SeedAsync()
    {
        using var scope  = serviceProvider.CreateScope();
        var context      = scope.ServiceProvider.GetRequiredService<MainDbContext>();
        var logger       = scope.ServiceProvider.GetRequiredService<ILogger<MainDbContext>>();

        try
        {
            await context.Database.MigrateAsync();
            //await SeedRegimenesFiscalesAsync(context);

            await MigrateTenantDb(await context.Tenants.ToListAsync());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ocurrió un error durante el seeding de la base de datos.");
            throw;
        }
    }

    private async Task MigrateTenantDb(IList<Tenant> tenants)
    {
        using var scope = serviceProvider.CreateScope();
        var tenantDbService = scope.ServiceProvider.GetRequiredService<ITenantDbService>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<MainDbSeeder>>();

        foreach (var tenant in tenants)
        {
            logger.LogInformation($"Migrating tenant {tenant.Subdomain}");

            await tenantDbService.Migrate(tenant.ConnectionString);

            logger.LogInformation($"Tenant {tenant.Subdomain} migrated at {DateTime.Now}");
        }

    }
    
}
