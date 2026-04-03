using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Queries.GetClientByIdQuery;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDTO?>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetClientByIdHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id);
        return client is null ? null : client.CastTo<ClientDTO>();
    }
}
