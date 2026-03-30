using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.TaxRegimes;
using Biller.Application.UseCase.Contracts;
using Biller.Domain.Entities.TenantsContext;

namespace Biller.Application.UseCase.Implementations;

public class TaxRegimesUseCase : ITaxRegimesUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public TaxRegimesUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TaxRegimeResponse>> GetAllAsync()
    {
        var taxRegimes = await _unitOfWork.TaxRegimes.GetAllAsync();
        return taxRegimes.Select(ToResponse);
    }

    public async Task<TaxRegimeResponse?> GetByIdAsync(int id)
    {
        var taxRegime = await _unitOfWork.TaxRegimes.GetByIdAsync(id);
        return taxRegime is null ? null : ToResponse(taxRegime);
    }

    private static TaxRegimeResponse ToResponse(TaxRegime taxRegime) => new()
    {
        Id          = taxRegime.Id,
        SatCode     = taxRegime.SatCode,
        Description = taxRegime.Description,
        Status      = taxRegime.Status.ToString()
    };
}
