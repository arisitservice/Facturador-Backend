using Biller.Application.Models.Tenant.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenant.TaxRegimes.Queries.GetAllTaxRegimesQuery;

public sealed class GetAllTaxRegimesQuery : IRequest<IEnumerable<TaxRegimeDTO>>
{
}
