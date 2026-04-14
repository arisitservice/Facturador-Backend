using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Accounts;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Accounts.Commands.UpdateAccountCommand;

public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, AccountDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public UpdateAccountHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountDTO> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(1)
            ?? throw new KeyNotFoundException("Account record was not found.");

        account.TenantName = request.TenantName;
        account.Company = request.Company;

        if (request.Image is not null)
        {
            using var ms = new MemoryStream();
            await request.Image.CopyToAsync(ms, cancellationToken);
            account.Image = Convert.ToBase64String(ms.ToArray());
        }

        await _unitOfWork.Accounts.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return account.CastTo<AccountDTO>();
    }
}
