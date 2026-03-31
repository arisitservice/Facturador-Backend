using Biller.Application.Models.Tenants.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetTaxRegimeByIdQuery;

public sealed class GetTaxRegimeByIdQuery : IRequest<TaxRegimeDTO?>
{
    public int Id { get; set; }
}
