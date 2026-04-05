using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.CancellationReasons;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.CancellationReasons.Queries.GetAllCancellationReasonsQuery;

public class GetAllCancellationReasonsHandler : IRequestHandler<GetAllCancellationReasonsQuery, IEnumerable<CancellationReasonDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllCancellationReasonsHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CancellationReasonDTO>> Handle(GetAllCancellationReasonsQuery request, CancellationToken cancellationToken)
    {
        var reasons = await _unitOfWork.CancellationReasons.GetAllAsync();
        return reasons.Select(x => x.CastTo<CancellationReasonDTO>()).ToList();
    }
}
