using Biller.Application.Models.Main;

namespace Biller.Application.UseCase.Contracts.Main;

public interface ITenantsUseCase
{
    Task<CreateTenantResponse> CrearAsync(CreateTenantRequest request);
}
