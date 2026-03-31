using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.DeleteClientCommand;

public sealed class DeleteClientCommand : IRequest
{
    public int Id { get; set; }
}
