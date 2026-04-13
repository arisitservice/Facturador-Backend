using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.DeleteClientTaxInfoCommand;

public sealed class DeleteClientTaxInfoCommand : IRequest
{
    public int Id { get; set; }
}
