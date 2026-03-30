
using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;
using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Infrastructure.Persistence.Context;
using Biller.Infrastructure.Persistence.Repositories.ApplicationDb;
using Biller.Infrastructure.Persistence.Repositories.MainDb;
using Biller.Infrastructure.Persistence.Services;
using Biller.Infrastructure.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Biller.Infrastructure;

public static class ConfigureServices
{
    public static void RegisterInfrastructureServicesServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        //services.AddHostedService<HolaMundoWorker>();
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Biller"),
            builder =>
            {
                builder.MigrationsAssembly(typeof(MainDbContext).Assembly.FullName);
            });
        });


        services.AddTransient<IApplicationDbContextGenerator, ApplicationDbContextGenerator>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ITaxRegimeRepository, TaxRegimeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMainUnitOfWork, MainUnitOfWork>();

        services.AddScoped<ITenantDbService, TenantDbService>();

    }

    //public static void RegisterDbLogginContextServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<LoggingDbContext>(options =>
    //    options.UseSqlServer(configuration.GetConnectionString("DriversLog")));
    //}
}
