using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.AccountTaxInfos;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAccountTaxInfoByIdQuery;

public class GetAccountTaxInfoByIdHandler : IRequestHandler<GetAccountTaxInfoByIdQuery, AccountTaxInfoDTO?>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAccountTaxInfoByIdHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountTaxInfoDTO?> Handle(GetAccountTaxInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var accountTaxInfo = await _unitOfWork.AccountTaxInfos.GetByIdAsync(request.Id);

        return accountTaxInfo is null ? null : accountTaxInfo.CastTo<AccountTaxInfoDTO>();
    }
}
