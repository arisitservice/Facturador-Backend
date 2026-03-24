using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Receptores;
using Biller.Application.UseCase.Contracts;

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
        var receptor = new Biller.Domain.Entities.Receptor
        {
            Nombre          = request.Name,
            Rfc             = request.TaxId,
            CodigoPostal    = request.PostalCode,
            RazonSocial     = request.BusinessName,
            DomicilioFiscal = request.TaxAddress,
            IdRegimenFiscal = request.TaxRegimeId,  
            IdUsoCfdi       = request.CfdiUseId
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

        receptor.Nombre          = request.Name;
        receptor.Rfc             = request.TaxId;
        receptor.CodigoPostal    = request.PostalCode;
        receptor.RazonSocial     = request.BusinessName;
        receptor.DomicilioFiscal = request.TaxAddress;
        receptor.IdRegimenFiscal = request.TaxRegimeId;
        receptor.IdUsoCfdi       = request.CfdiUseId;

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

    private static ReceptorResponse ToResponse(Biller.Domain.Entities.Receptor r) => new()
    {
        Id              = r.Id,
        DomicilioFiscal = r.DomicilioFiscal,
        CodigoPostal    = r.CodigoPostal,
        Nombre          = r.Nombre,
        RazonSocial     = r.RazonSocial,
        Rfc             = r.Rfc,
        IdRegimenFiscal = r.IdRegimenFiscal,
        IdUsoCfdi       = r.IdUsoCfdi
    };
}
