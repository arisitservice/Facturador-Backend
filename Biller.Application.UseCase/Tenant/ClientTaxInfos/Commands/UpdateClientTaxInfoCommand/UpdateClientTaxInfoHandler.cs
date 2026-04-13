using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.UpdateClientTaxInfoCommand;

public class UpdateClientTaxInfoHandler : IRequestHandler<UpdateClientTaxInfoCommand, ClientTaxInfoDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public UpdateClientTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientTaxInfoDTO> Handle(UpdateClientTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var clientTaxInfo = await _unitOfWork.ClientTaxInfos.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"ClientTaxInfo with Id {request.Id} was not found.");

        clientTaxInfo.TaxAddress   = request.TaxAddress;
        clientTaxInfo.PostalCode   = request.PostalCode;
        clientTaxInfo.BusinessName = request.BusinessName;
        clientTaxInfo.TaxId        = request.TaxId;
        clientTaxInfo.Default      = request.Default;
        clientTaxInfo.TaxRegimeId  = request.TaxRegimeId;

        await _unitOfWork.ClientTaxInfos.UpdateAsync(clientTaxInfo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return clientTaxInfo.CastTo<ClientTaxInfoDTO>();
    }
}
