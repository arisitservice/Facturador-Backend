using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Queries.GetAllClientsQuery;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllClientsHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _unitOfWork.Receptores.GetAllAsync();
        return clients.Select(ClientDTO.FromEntity);
    }
}
