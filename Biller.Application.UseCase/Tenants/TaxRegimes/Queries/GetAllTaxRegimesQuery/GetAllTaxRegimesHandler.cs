using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.TaxRegimes;
using MediatR;

namespace Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetAllTaxRegimesQuery;

public class GetAllTaxRegimesHandler : IRequestHandler<GetAllTaxRegimesQuery, IEnumerable<TaxRegimeDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTaxRegimesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TaxRegimeDTO>> Handle(GetAllTaxRegimesQuery request, CancellationToken cancellationToken)
    {
        var taxRegimes = await _unitOfWork.TaxRegimes.GetAllAsync();
        return taxRegimes.Select(TaxRegimeDTO.FromEntity);
    }
}
