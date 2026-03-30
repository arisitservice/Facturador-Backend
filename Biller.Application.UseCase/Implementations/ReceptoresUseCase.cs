using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Receptores;
using Biller.Application.UseCase.Contracts;
using Biller.Domain.Entities.TenantsContext;

namespace Biller.Application.UseCase.Implementations;

public class ReceptoresUseCase : IReceptoresUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public ReceptoresUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReceptorResponse> CrearAsync(ReceptorRequest request)
    {
        var receptor = new Client
        {
            Name          = request.Name,
            TaxId             = request.TaxId,
            PostalCode    = request.PostalCode,
            BusinessName     = request.BusinessName,
            TaxAddress = request.TaxAddress,
            TaxRegimeId = request.TaxRegimeId
        };

        await _unitOfWork.Receptores.AddAsync(receptor);
        await _unitOfWork.SaveChangesAsync();

        return ToResponse(receptor);
    }

    public async Task<IEnumerable<ReceptorResponse>> ObtenerTodosAsync()
    {
        var receptores = await _unitOfWork.Receptores.GetAllAsync();
        return receptores.Select(ToResponse);
    }

    public async Task<ReceptorResponse?> ObtenerPorIdAsync(int id)
    {
        var receptor = await _unitOfWork.Receptores.GetByIdAsync(id);
        return receptor is null ? null : ToResponse(receptor);
    }

    public async Task<ReceptorResponse> ActualizarAsync(int id, ReceptorRequest request)
    {
        var receptor = await _unitOfWork.Receptores.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Receptor con Id {id} no encontrado.");

        receptor.Name          = request.Name;
        receptor.TaxId = request.TaxId;
        receptor.PostalCode    = request.PostalCode;
        receptor.BusinessName = request.BusinessName;
        receptor.TaxAddress = request.TaxAddress;
        receptor.TaxRegimeId = request.TaxRegimeId;

        await _unitOfWork.Receptores.UpdateAsync(receptor);
        await _unitOfWork.SaveChangesAsync();

        return ToResponse(receptor);
    }

    public async Task EliminarAsync(int id)
    {
        var receptor = await _unitOfWork.Receptores.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Receptor con Id {id} no encontrado.");

        await _unitOfWork.Receptores.DeleteAsync(receptor.Id);
        await _unitOfWork.SaveChangesAsync();
    }

    private static ReceptorResponse ToResponse(Client r) => new()
    {
        Id              = r.Id,
        DomicilioFiscal = r.TaxAddress,
        CodigoPostal    = r.PostalCode,
        Nombre          = r.Name,
        RazonSocial     = r.BusinessName,
        Rfc             = r.TaxId,
        IdRegimenFiscal = r.TaxRegimeId
    };
}
