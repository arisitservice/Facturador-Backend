using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.CfdiUses;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.CfdiUses.Queries.GetAllCfdiUsesQuery;

public class GetAllCfdiUsesHandler : IRequestHandler<GetAllCfdiUsesQuery, IEnumerable<CfdiUseDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllCfdiUsesHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CfdiUseDTO>> Handle(GetAllCfdiUsesQuery request, CancellationToken cancellationToken)
    {
        var cfdiUses = await _unitOfWork.CfdiUses.GetAllAsync();
        return cfdiUses.Select(x => x.CastTo<CfdiUseDTO>()).ToList();
    }
}
