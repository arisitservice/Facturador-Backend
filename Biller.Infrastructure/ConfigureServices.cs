
using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Infrastructure.Persistence.Contexts;
using Biller.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biller.Infrastructure;

public static class ConfigureServices
{
    public static void RegisterInfrastructureServicesServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Biller"),
            builder =>
            {
                builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        });


        services.AddScoped<IReceptorRepository, ReceptorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    //public static void RegisterDbLogginContextServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<LoggingDbContext>(options =>
    //    options.UseSqlServer(configuration.GetConnectionString("DriversLog")));
    //}
}
