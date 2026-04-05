using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Currencies;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Currencies.Queries.GetAllCurrenciesQuery;

public class GetAllCurrenciesHandler : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<CurrencyDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllCurrenciesHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CurrencyDTO>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var currencies = await _unitOfWork.Currencies.GetAllAsync();
        return currencies.Select(x => x.CastTo<CurrencyDTO>()).ToList();
    }
}
