using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Domain.Entities.TenantsContext;
using Biller.Domain.Enums;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Services;

public class TenantDbService : ITenantDbService
{
  
    public async Task Create(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer(connectionString)
        .Options;

        using var dbContext = new ApplicationDbContext(options);
        await dbContext.Database.MigrateAsync();

        var regimenes = GetDefaultRegimes();

        await dbContext.TaxRegimes.AddRangeAsync(regimenes);
        await dbContext.SaveChangesAsync();
    }

    private List<TaxRegime> GetDefaultRegimes()
    {
        return new List<TaxRegime>
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
    }
}
