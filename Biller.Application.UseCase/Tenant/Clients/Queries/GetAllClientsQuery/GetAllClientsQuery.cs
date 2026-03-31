using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Queries.GetAllClientsQuery;

public sealed class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
{
}
