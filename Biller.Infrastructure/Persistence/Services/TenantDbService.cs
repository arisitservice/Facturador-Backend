using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Biller.Infrastructure.Persistence.Services;

public class TenantDbService : ITenantDbService
{
  
    public async Task Create(string connectionString, TenantUser owner)
    {
        var options = new DbContextOptionsBuilder<TenantDbContext>()
        .UseNpgsql(connectionString)
        .Options;

        using var dbContext = new TenantDbContext(options);

        await dbContext.Database.MigrateAsync();

        await SeedDefaultRegimes(dbContext);
        await SeedDefaultCfdiUses(dbContext);
        await SeedDefaultMeasurementUnits(dbContext);
        await SeedDefaultProducts(dbContext);
        await SeedDefaultCancellationReasons(dbContext);
        await SeedDefaultCurrencies(dbContext);

        await dbContext.TenantUsers.AddAsync(owner);

        await dbContext.SaveChangesAsync();
    }

    public async Task Migrate(string connectionString)
    {
        var options = new DbContextOptionsBuilder<TenantDbContext>()
       .UseNpgsql(connectionString)
       .Options;

        using var dbContext = new TenantDbContext(options);

        await dbContext.Database.MigrateAsync();

        await SeedDefaultCfdiUses(dbContext);
        await SeedDefaultMeasurementUnits(dbContext);
        await SeedDefaultProducts(dbContext);
        await SeedDefaultCancellationReasons(dbContext);
        await SeedDefaultCurrencies(dbContext);

        await dbContext.SaveChangesAsync();
    }

    private async Task SeedDefaultRegimes(TenantDbContext tenantDbContext)
    {
        if(await tenantDbContext.TaxRegimes.AnyAsync()) return;

        var regimes = new List<TaxRegime>
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

        await tenantDbContext.TaxRegimes.AddRangeAsync(regimes);
    }

    private async Task SeedDefaultCfdiUses(TenantDbContext tenantDbContext)
    {
        if (await tenantDbContext.CfdiUses.AnyAsync()) return;

        var cfdiUses = new List<CfdiUse>
        {
            new() { SatCode = "G03", Description = "Gastos en General",                          Status = Status.Active },
            new() { SatCode = "S01", Description = "Sin Efectos Fiscales",                       Status = Status.Active },
            new() { SatCode = "G02", Description = "Devoluciones, descuentos o bonificaciones",  Status = Status.Active },
        };

        await tenantDbContext.CfdiUses.AddRangeAsync(cfdiUses);
    }

    private async Task SeedDefaultMeasurementUnits(TenantDbContext tenantDbContext)
    {
        if (await tenantDbContext.MeasurementUnits.AnyAsync()) return;

        var units = new List<MeasurementUnit>
        {
            new() { SatCode = "H87", Description = "Pieza",               Status = Status.Active },
            new() { SatCode = "E48", Description = "Unidad de Servicio",  Status = Status.Active },
            new() { SatCode = "ACT", Description = "Actividad",           Status = Status.Active },
        };

        await tenantDbContext.MeasurementUnits.AddRangeAsync(units);
    }

    private async Task SeedDefaultProducts(TenantDbContext tenantDbContext)
    {
        if (await tenantDbContext.Products.AnyAsync()) return;

        var products = new List<Product>
        {
            new() { SatCode = 78121603, Description = "Tarifa de los fletes",                                          Status = Status.Active },
            new() { SatCode = 78131802, Description = "Servicios de almacenaje bajo control aduanero",                 Status = Status.Active },
            new() { SatCode = 84131501, Description = "Seguros de edificios o del contenido de edificios",             Status = Status.Active },
            new() { SatCode = 78131601, Description = "Almacenaje de mercancías embandejadas",                         Status = Status.Active },
            new() { SatCode = 24141501, Description = "Película elástica para envoltura",                              Status = Status.Active },
            new() { SatCode = 80131502, Description = "Arrendamiento de instalaciones comerciales o industriales",     Status = Status.Active },
            new() { SatCode = 78121601, Description = "Carga y descarga de mercancías",                                Status = Status.Active },
            new() { SatCode = 78102205, Description = "Servicios de entrega local de cartas o paquetes pequeños",      Status = Status.Active },
            new() { SatCode = 24112701, Description = "Pallets de madera",                                             Status = Status.Active },
            new() { SatCode = 43232408, Description = "Software de desarrollo de plataforma Web",                      Status = Status.Active },
            new() { SatCode = 84111506, Description = "Servicios de facturación",                                      Status = Status.Active },
        };

        await tenantDbContext.Products.AddRangeAsync(products);
    }

    private async Task SeedDefaultCancellationReasons(TenantDbContext tenantDbContext)
    {
        if (await tenantDbContext.CancellationReasons.AnyAsync()) return;

        var reasons = new List<CancellationReason>
        {
            new() { SatCode = "01", Description = "Comprobante emitido con errores con relación",                Status = Status.Active },
            new() { SatCode = "02", Description = "Comprobante emitido con errores sin relación",               Status = Status.Active },
            new() { SatCode = "03", Description = "No se llevó a cabo la operación",                            Status = Status.Active },
            new() { SatCode = "04", Description = "Operación nominativa relacionada en una factura global",     Status = Status.Active },
        };

        await tenantDbContext.CancellationReasons.AddRangeAsync(reasons);
    }

    private async Task SeedDefaultCurrencies(TenantDbContext tenantDbContext)
    {
        if (await tenantDbContext.Currencies.AnyAsync()) return;

        var currencies = new List<Currency>
        {
            new() { SatCode = "MXN", Description = "Peso Mexicano", Status = Status.Active },
            new() { SatCode = "USD", Description = "Dólar",         Status = Status.Active },
        };

        await tenantDbContext.Currencies.AddRangeAsync(currencies);
    }


}
