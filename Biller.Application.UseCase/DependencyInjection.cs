using Biller.Application.UseCase.Contracts;
using Biller.Application.UseCase.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Biller.Application.UseCase;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICrearComprobanteUseCase, CrearComprobanteUseCase>();
        services.AddScoped<IReceptoresUseCase, ReceptoresUseCase>();

        return services;
    }
}
