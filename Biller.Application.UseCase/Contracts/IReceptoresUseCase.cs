using Biller.Application.Models.Receptores;

namespace Biller.Application.UseCase.Contracts;

public interface IReceptoresUseCase
{
    Task<ReceptorResponse> CrearAsync(ReceptorRequest request);
    Task<IEnumerable<ReceptorResponse>> ObtenerTodosAsync();
    Task<ReceptorResponse?> ObtenerPorIdAsync(int id);
    Task<ReceptorResponse> ActualizarAsync(int id, ReceptorRequest request);
    Task EliminarAsync(int id);
}
