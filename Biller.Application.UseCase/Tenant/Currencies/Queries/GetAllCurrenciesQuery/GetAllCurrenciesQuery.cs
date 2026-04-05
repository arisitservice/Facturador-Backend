using Biller.Application.Models.Tenant.Currencies;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Currencies.Queries.GetAllCurrenciesQuery;

public sealed class GetAllCurrenciesQuery : IRequest<IEnumerable<CurrencyDTO>>
{
}
