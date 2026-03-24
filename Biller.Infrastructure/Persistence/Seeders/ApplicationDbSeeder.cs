using Biller.Domain.Entities;
using Biller.Domain.Enums;
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
        var context      = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var logger       = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

        try
        {
            await context.Database.MigrateAsync();
            await SeedRegimenesFiscalesAsync(context);
            await SeedUsosCfdiAsync(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ocurrió un error durante el seeding de la base de datos.");
            throw;
        }
    }

    private static async Task SeedRegimenesFiscalesAsync(ApplicationDbContext context)
    {
        if (await context.RegimenesFiscales.AnyAsync())
            return;

        var regimenes = new List<RegimenFiscal>
        {
            new() { ClaveSat = 601, Descripcion = "General de Ley Personas Morales",                                                                          Estatus = Estatus.Activo },
            new() { ClaveSat = 603, Descripcion = "Personas Morales con Fines no Lucrativos",                                                                 Estatus = Estatus.Activo },
            new() { ClaveSat = 605, Descripcion = "Sueldos y Salarios e Ingresos Asimilados a Salarios",                                                      Estatus = Estatus.Activo },
            new() { ClaveSat = 606, Descripcion = "Arrendamiento",                                                                                            Estatus = Estatus.Activo },
            new() { ClaveSat = 607, Descripcion = "Régimen de Enajenación o Adquisición de Bienes",                                                           Estatus = Estatus.Activo },
            new() { ClaveSat = 608, Descripcion = "Demás ingresos",                                                                                           Estatus = Estatus.Activo },
            new() { ClaveSat = 610, Descripcion = "Residentes en el Extranjero sin Establecimiento Permanente en México",                                     Estatus = Estatus.Activo },
            new() { ClaveSat = 611, Descripcion = "Ingresos por Dividendos (socios y accionistas)",                                                           Estatus = Estatus.Activo },
            new() { ClaveSat = 612, Descripcion = "Personas Físicas con Actividades Empresariales y Profesionales",                                           Estatus = Estatus.Activo },
            new() { ClaveSat = 614, Descripcion = "Ingresos por intereses",                                                                                   Estatus = Estatus.Activo },
            new() { ClaveSat = 615, Descripcion = "Régimen de los ingresos por obtención de premios",                                                         Estatus = Estatus.Activo },
            new() { ClaveSat = 616, Descripcion = "Sin obligaciones fiscales",                                                                                 Estatus = Estatus.Activo },
            new() { ClaveSat = 620, Descripcion = "Sociedades Cooperativas de Producción que optan por diferir sus ingresos",                                 Estatus = Estatus.Activo },
            new() { ClaveSat = 621, Descripcion = "Incorporación Fiscal",                                                                                     Estatus = Estatus.Activo },
            new() { ClaveSat = 622, Descripcion = "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras",                                                 Estatus = Estatus.Activo },
            new() { ClaveSat = 623, Descripcion = "Opcional para Grupos de Sociedades",                                                                       Estatus = Estatus.Activo },
            new() { ClaveSat = 624, Descripcion = "Coordinados",                                                                                              Estatus = Estatus.Activo },
            new() { ClaveSat = 625, Descripcion = "Régimen de las Actividades Empresariales con ingresos a través de Plataformas Tecnológicas",              Estatus = Estatus.Activo },
            new() { ClaveSat = 626, Descripcion = "Régimen Simplificado de Confianza (RESICO)",                                                               Estatus = Estatus.Activo },
        };

        await context.RegimenesFiscales.AddRangeAsync(regimenes);
        await context.SaveChangesAsync();
    }

    private static async Task SeedUsosCfdiAsync(ApplicationDbContext context)
    {
        if (await context.UsosCfdi.AnyAsync())
            return;

        var usos = new List<UsoCfdi>
        {
            new() { ClaveSat = "G01", Descripcion = "Adquisición de mercancias",                                                                              Estatus = Estatus.Activo },
            new() { ClaveSat = "G02", Descripcion = "Devoluciones, descuentos o bonificaciones",                                                              Estatus = Estatus.Activo },
            new() { ClaveSat = "G03", Descripcion = "Gastos en general",                                                                                      Estatus = Estatus.Activo },
            new() { ClaveSat = "I01", Descripcion = "Construcciones",                                                                                         Estatus = Estatus.Activo },
            new() { ClaveSat = "I02", Descripcion = "Mobilario y equipo de oficina por inversiones",                                                          Estatus = Estatus.Activo },
            new() { ClaveSat = "I03", Descripcion = "Equipo de transporte",                                                                                   Estatus = Estatus.Activo },
            new() { ClaveSat = "I04", Descripcion = "Equipo de computo y accesorios",                                                                         Estatus = Estatus.Activo },
            new() { ClaveSat = "I05", Descripcion = "Dados, troqueles, moldes, matrices y herramental",                                                       Estatus = Estatus.Activo },
            new() { ClaveSat = "I06", Descripcion = "Comunicaciones telefónicas",                                                                             Estatus = Estatus.Activo },
            new() { ClaveSat = "I07", Descripcion = "Comunicaciones satelitales",                                                                             Estatus = Estatus.Activo },
            new() { ClaveSat = "I08", Descripcion = "Otra maquinaria y equipo",                                                                               Estatus = Estatus.Activo },
            new() { ClaveSat = "D01", Descripcion = "Honorarios médicos, dentales y gastos hospitalarios",                                                    Estatus = Estatus.Activo },
            new() { ClaveSat = "D02", Descripcion = "Gastos médicos por incapacidad o discapacidad",                                                          Estatus = Estatus.Activo },
            new() { ClaveSat = "D03", Descripcion = "Gastos funerales",                                                                                       Estatus = Estatus.Activo },
            new() { ClaveSat = "D04", Descripcion = "Donativos",                                                                                              Estatus = Estatus.Activo },
            new() { ClaveSat = "D05", Descripcion = "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)",                     Estatus = Estatus.Activo },
            new() { ClaveSat = "D06", Descripcion = "Aportaciones voluntarias al SAR",                                                                        Estatus = Estatus.Activo },
            new() { ClaveSat = "D07", Descripcion = "Primas por seguros de gastos médicos",                                                                   Estatus = Estatus.Activo },
            new() { ClaveSat = "D08", Descripcion = "Gastos de transportación escolar obligatoria",                                                           Estatus = Estatus.Activo },
            new() { ClaveSat = "D09", Descripcion = "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones",                   Estatus = Estatus.Activo },
            new() { ClaveSat = "D10", Descripcion = "Pagos por servicios educativos (colegiaturas)",                                                          Estatus = Estatus.Activo },
            new() { ClaveSat = "S01", Descripcion = "Sin efectos fiscales",                                                                                   Estatus = Estatus.Activo },
            new() { ClaveSat = "CP01", Descripcion = "Pagos",                                                                                                 Estatus = Estatus.Activo },
            new() { ClaveSat = "CN01", Descripcion = "Nómina",                                                                                                Estatus = Estatus.Activo },
        };

        await context.UsosCfdi.AddRangeAsync(usos);
        await context.SaveChangesAsync();
    }
}
