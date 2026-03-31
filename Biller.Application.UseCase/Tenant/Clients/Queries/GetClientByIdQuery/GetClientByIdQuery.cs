using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Queries.GetClientByIdQuery;

public sealed class GetClientByIdQuery : IRequest<ClientDTO?>
{
    public int Id { get; set; }
}
