using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.TaxRegimes;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.TaxRegimes.Queries.GetAllTaxRegimesQuery;

public class GetAllTaxRegimesHandler : IRequestHandler<GetAllTaxRegimesQuery, IEnumerable<TaxRegimeDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllTaxRegimesHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TaxRegimeDTO>> Handle(GetAllTaxRegimesQuery request, CancellationToken cancellationToken)
    {
        var taxRegimes = await _unitOfWork.TaxRegimes.GetAllAsync();
        return taxRegimes.Select(x => x.CastTo<TaxRegimeDTO>()).ToList();
    }
}
