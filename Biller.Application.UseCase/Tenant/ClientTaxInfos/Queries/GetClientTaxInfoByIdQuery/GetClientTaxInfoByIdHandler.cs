using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetClientTaxInfoByIdQuery;

public class GetClientTaxInfoByIdHandler : IRequestHandler<GetClientTaxInfoByIdQuery, ClientTaxInfoDTO?>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetClientTaxInfoByIdHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientTaxInfoDTO?> Handle(GetClientTaxInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var clientTaxInfo = await _unitOfWork.ClientTaxInfos.GetByIdAsync(request.Id);

        return clientTaxInfo is null ? null : clientTaxInfo.CastTo<ClientTaxInfoDTO>();
    }
}
