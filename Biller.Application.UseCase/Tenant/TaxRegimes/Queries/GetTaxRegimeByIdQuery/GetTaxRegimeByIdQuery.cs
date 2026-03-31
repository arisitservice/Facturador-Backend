using Biller.Application.Models.Tenant.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenant.TaxRegimes.Queries.GetTaxRegimeByIdQuery;

public sealed class GetTaxRegimeByIdQuery : IRequest<TaxRegimeDTO?>
{
    public int Id { get; set; }
}
