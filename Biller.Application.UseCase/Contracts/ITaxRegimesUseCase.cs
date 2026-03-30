using Biller.Application.Models.TaxRegimes;

namespace Biller.Application.UseCase.Contracts;

public interface ITaxRegimesUseCase
{
    Task<IEnumerable<TaxRegimeResponse>> GetAllAsync();
    Task<TaxRegimeResponse?> GetByIdAsync(int id);
}
