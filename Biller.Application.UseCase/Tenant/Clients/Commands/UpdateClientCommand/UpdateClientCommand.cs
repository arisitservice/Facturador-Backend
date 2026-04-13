using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.UpdateClientCommand;

public sealed class UpdateClientCommand : IRequest<ClientDTO>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

