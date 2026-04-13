using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetAllClientTaxInfosQuery;

public class GetAllClientTaxInfosHandler : IRequestHandler<GetAllClientTaxInfosQuery, IEnumerable<ClientTaxInfoDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllClientTaxInfosHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClientTaxInfoDTO>> Handle(GetAllClientTaxInfosQuery request, CancellationToken cancellationToken)
    {
        var clientTaxInfos = await _unitOfWork.ClientTaxInfos.GetAllByClientIdAsync(request.ClientId);

        return clientTaxInfos.Select(c => c.CastTo<ClientTaxInfoDTO>()).ToList();
    }
}
