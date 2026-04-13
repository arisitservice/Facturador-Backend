using Biller.Application.Models.Tenant.AccountTaxInfos;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAccountTaxInfoByIdQuery;

public sealed class GetAccountTaxInfoByIdQuery : IRequest<AccountTaxInfoDTO?>
{
    public int Id { get; set; }
}
