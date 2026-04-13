using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.AccountTaxInfos;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAllAccountTaxInfosQuery;

public class GetAllAccountTaxInfosHandler : IRequestHandler<GetAllAccountTaxInfosQuery, IEnumerable<AccountTaxInfoDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllAccountTaxInfosHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AccountTaxInfoDTO>> Handle(GetAllAccountTaxInfosQuery request, CancellationToken cancellationToken)
    {
        var accountTaxInfos = await _unitOfWork.AccountTaxInfos.GetAllAsync();

        return accountTaxInfos.Select(a => a.CastTo<AccountTaxInfoDTO>()).ToList();
    }
}
