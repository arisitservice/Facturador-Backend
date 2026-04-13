using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.AccountTaxInfos;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.UpdateAccountTaxInfoCommand;

public class UpdateAccountTaxInfoHandler : IRequestHandler<UpdateAccountTaxInfoCommand, AccountTaxInfoDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public UpdateAccountTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountTaxInfoDTO> Handle(UpdateAccountTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var accountTaxInfo = await _unitOfWork.AccountTaxInfos.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"AccountTaxInfo with Id {request.Id} was not found.");

        accountTaxInfo.TaxAddress   = request.TaxAddress;
        accountTaxInfo.PostalCode   = request.PostalCode;
        accountTaxInfo.BusinessName = request.BusinessName;
        accountTaxInfo.TaxId        = request.TaxId;
        accountTaxInfo.Default      = request.Default;
        accountTaxInfo.TaxRegimeId  = request.TaxRegimeId;

        await _unitOfWork.AccountTaxInfos.UpdateAsync(accountTaxInfo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return accountTaxInfo.CastTo<AccountTaxInfoDTO>();
    }
}
