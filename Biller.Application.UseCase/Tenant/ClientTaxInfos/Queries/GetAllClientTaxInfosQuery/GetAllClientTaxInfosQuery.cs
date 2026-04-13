using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetAllClientTaxInfosQuery;

public sealed class GetAllClientTaxInfosQuery : IRequest<IEnumerable<ClientTaxInfoDTO>>
{
    public int ClientId { get; set; }
}
