using Biller.Application.Models.Tenant.CfdiUses;
using MediatR;

namespace Biller.Application.UseCase.Tenant.CfdiUses.Queries.GetAllCfdiUsesQuery;

public sealed class GetAllCfdiUsesQuery : IRequest<IEnumerable<CfdiUseDTO>>
{
}
