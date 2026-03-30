using Biller.Domain.Entities.TenantsContext;
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

    private static async Task SeedRegimenesFiscalesAsync(ApplicationDbContext context)
    {
        if (await context.TaxRegimes.AnyAsync())
            return;

        var regimenes = new List<TaxRegime>
        {
            new() { SatCode = 601, Description = "General de Ley Personas Morales",                                                                          Status = Status.Active },
            new() { SatCode = 603, Description = "Personas Morales con Fines no Lucrativos",                                                                 Status = Status.Active },
            new() { SatCode = 605, Description = "Sueldos y Salarios e Ingresos Asimilados a Salarios",                                                      Status = Status.Active },
            new() { SatCode = 606, Description = "Arrendamiento",                                                                                            Status = Status.Active },
            new() { SatCode = 607, Description = "Régimen de Enajenación o Adquisición de Bienes",                                                           Status = Status.Active },
            new() { SatCode = 608, Description = "Demás ingresos",                                                                                           Status = Status.Active },
            new() { SatCode = 610, Description = "Residentes en el Extranjero sin Establecimiento Permanente en México",                                     Status = Status.Active },
            new() { SatCode = 611, Description = "Ingresos por Dividendos (socios y accionistas)",                                                           Status = Status.Active },
            new() { SatCode = 612, Description = "Personas Físicas con Actividades Empresariales y Profesionales",                                           Status = Status.Active },
            new() { SatCode = 614, Description = "Ingresos por intereses",                                                                                   Status = Status.Active },
            new() { SatCode = 615, Description = "Régimen de los ingresos por obtención de premios",                                                         Status = Status.Active },
            new() { SatCode = 616, Description = "Sin obligaciones fiscales",                                                                                Status = Status.Active },
            new() { SatCode = 620, Description = "Sociedades Cooperativas de Producción que optan por diferir sus ingresos",                                 Status = Status.Active },
            new() { SatCode = 621, Description = "Incorporación Fiscal",                                                                                     Status = Status.Active },
            new() { SatCode = 622, Description = "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras",                                                 Status = Status.Active },
            new() { SatCode = 623, Description = "Opcional para Grupos de Sociedades",                                                                       Status = Status.Active },
            new() { SatCode = 624, Description = "Coordinados",                                                                                              Status = Status.Active },
            new() { SatCode = 625, Description = "Régimen de las Actividades Empresariales con ingresos a través de Plataformas Tecnológicas",               Status = Status.Active },
            new() { SatCode = 626, Description = "Régimen Simplificado de Confianza (RESICO)",                                                               Status = Status.Active },
        };

        await context.TaxRegimes.AddRangeAsync(regimenes);
        await context.SaveChangesAsync();
    }

    
}
