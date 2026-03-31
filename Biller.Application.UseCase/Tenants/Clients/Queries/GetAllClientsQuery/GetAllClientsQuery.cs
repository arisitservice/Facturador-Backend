using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Queries.GetAllClientsQuery;

public sealed class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
{
}
