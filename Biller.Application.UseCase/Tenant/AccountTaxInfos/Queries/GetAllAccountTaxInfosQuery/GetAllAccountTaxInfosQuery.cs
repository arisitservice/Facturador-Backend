using Biller.Application.Models.Tenant.AccountTaxInfos;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAllAccountTaxInfosQuery;

public sealed class GetAllAccountTaxInfosQuery : IRequest<IEnumerable<AccountTaxInfoDTO>>
{
}
