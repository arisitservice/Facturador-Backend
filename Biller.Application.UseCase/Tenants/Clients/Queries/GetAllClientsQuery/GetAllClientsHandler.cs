using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Queries.GetAllClientsQuery;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllClientsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _unitOfWork.Receptores.GetAllAsync();
        return clients.Select(ClientDTO.FromEntity);
    }
}
