using Biller.Application.Infrastructure.Interface.Persistence;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.DeleteAccountTaxInfoCommand;

public class DeleteAccountTaxInfoHandler : IRequestHandler<DeleteAccountTaxInfoCommand>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public DeleteAccountTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAccountTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var accountTaxInfo = await _unitOfWork.TaxInfos.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"AccountTaxInfo with Id {request.Id} was not found.");

        await _unitOfWork.TaxInfos.DeleteAsync(accountTaxInfo.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
