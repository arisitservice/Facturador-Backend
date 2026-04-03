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
        return await _unitOfWork.Clients.GetAllAsync();
    }
}
