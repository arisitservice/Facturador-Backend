using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenant.TaxRegimes.Queries.GetTaxRegimeByIdQuery;

public class GetTaxRegimeByIdHandler : IRequestHandler<GetTaxRegimeByIdQuery, TaxRegimeDTO?>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetTaxRegimeByIdHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TaxRegimeDTO?> Handle(GetTaxRegimeByIdQuery request, CancellationToken cancellationToken)
    {
        var taxRegime = await _unitOfWork.TaxRegimes.GetByIdAsync(request.Id);
        return taxRegime is null ? null : TaxRegimeDTO.FromEntity(taxRegime);
    }
}
