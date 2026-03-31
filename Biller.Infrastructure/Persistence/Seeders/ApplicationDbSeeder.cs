using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;
using Biller.Infrastructure.Persistence.Context;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Biller.Infrastructure.Persistence.Seeders;

public static class ApplicationDbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope  = serviceProvider.CreateScope();
        var context      = scope.ServiceProvider.GetRequiredService<MainDbContext>();
        var logger       = scope.ServiceProvider.GetRequiredService<ILogger<MainDbContext>>();

        try
        {
            await context.Database.MigrateAsync();
            //await SeedRegimenesFiscalesAsync(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ocurrió un error durante el seeding de la base de datos.");
            throw;
        }
    }
    
}
