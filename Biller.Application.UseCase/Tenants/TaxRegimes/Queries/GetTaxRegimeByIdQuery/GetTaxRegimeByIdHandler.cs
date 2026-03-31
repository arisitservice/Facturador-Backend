using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetTaxRegimeByIdQuery;

public class GetTaxRegimeByIdHandler : IRequestHandler<GetTaxRegimeByIdQuery, TaxRegimeDTO?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTaxRegimeByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TaxRegimeDTO?> Handle(GetTaxRegimeByIdQuery request, CancellationToken cancellationToken)
    {
        var taxRegime = await _unitOfWork.TaxRegimes.GetByIdAsync(request.Id);
        return taxRegime is null ? null : TaxRegimeDTO.FromEntity(taxRegime);
    }
}
