using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.AccountTaxInfos;
using Biller.Domain.Entities.Tenant;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.CreateAccountTaxInfoCommand;

public class CreateAccountTaxInfoHandler : IRequestHandler<CreateAccountTaxInfoCommand, AccountTaxInfoDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public CreateAccountTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountTaxInfoDTO> Handle(CreateAccountTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var accountTaxInfo = new AccountTaxInfo
        {
            TaxAddress   = request.TaxAddress,
            PostalCode   = request.PostalCode,
            BusinessName = request.BusinessName,
            TaxId        = request.TaxId,
            Default      = request.Default,
            TaxRegimeId  = request.TaxRegimeId
        };

        await _unitOfWork.AccountTaxInfos.AddAsync(accountTaxInfo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return accountTaxInfo.CastTo<AccountTaxInfoDTO>();
    }
}
