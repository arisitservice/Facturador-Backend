using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetClientTaxInfoByIdQuery;

public sealed class GetClientTaxInfoByIdQuery : IRequest<ClientTaxInfoDTO?>
{
    public int Id { get; set; }
}
