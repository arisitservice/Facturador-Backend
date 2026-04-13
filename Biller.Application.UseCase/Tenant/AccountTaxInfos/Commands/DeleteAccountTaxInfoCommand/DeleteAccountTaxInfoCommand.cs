using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.DeleteAccountTaxInfoCommand;

public sealed class DeleteAccountTaxInfoCommand : IRequest
{
    public int Id { get; set; }
}
