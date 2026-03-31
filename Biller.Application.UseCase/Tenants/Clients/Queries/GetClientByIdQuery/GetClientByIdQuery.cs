using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Queries.GetClientByIdQuery;

public sealed class GetClientByIdQuery : IRequest<ClientDTO?>
{
    public int Id { get; set; }
}
