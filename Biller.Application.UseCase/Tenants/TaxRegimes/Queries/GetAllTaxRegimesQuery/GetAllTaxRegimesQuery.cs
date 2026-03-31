using Biller.Application.Models.Tenants.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetAllTaxRegimesQuery;

public sealed class GetAllTaxRegimesQuery : IRequest<IEnumerable<TaxRegimeDTO>>
{
}
