
using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;
using Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;
using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Infrastructure.Persistence.Context;
using Biller.Infrastructure.Persistence.Repositories.TenantDb;
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

        /*Main db context*/
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMainUnitOfWork, MainUnitOfWork>();

        /*Tenant db context*/
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientTaxInfoRepository, ClientTaxInfoRepository>();
        services.AddScoped<IAccountTaxInfoRepository, AccountTaxInfoRepository>();
        services.AddScoped<ITaxRegimeRepository, TaxRegimeRepository>();
        services.AddScoped<ITenantUserRepository, TenantUserRepository>();
        services.AddScoped<ICfdiUseRepository, CfdiUseRepository>();
        services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICancellationReasonRepository, CancellationReasonRepository>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ITenantUnitOfWork, TenantUnitOfWork>();


        services.AddScoped<ITenantDbService, TenantDbService>();
        services.AddTransient<ITenantDbContextGenerator, TenantDbContextGenerator>();
    }

    //public static void RegisterDbLogginContextServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<LoggingDbContext>(options =>
    //    options.UseSqlServer(configuration.GetConnectionString("DriversLog")));
    //}
}
