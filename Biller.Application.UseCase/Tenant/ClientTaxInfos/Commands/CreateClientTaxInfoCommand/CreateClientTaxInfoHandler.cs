using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Domain.Entities.Tenant;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.CreateClientTaxInfoCommand;

public class CreateClientTaxInfoHandler : IRequestHandler<CreateClientTaxInfoCommand, ClientTaxInfoDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public CreateClientTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientTaxInfoDTO> Handle(CreateClientTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var clientTaxInfo = new ClientTaxInfo
        {
            TaxAddress   = request.TaxAddress,
            PostalCode   = request.PostalCode,
            BusinessName = request.BusinessName,
            TaxId        = request.TaxId,
            Default      = request.Default,
            ClientId     = request.ClientId,
            TaxRegimeId  = request.TaxRegimeId
        };

        await _unitOfWork.ClientTaxInfos.AddAsync(clientTaxInfo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return clientTaxInfo.CastTo<ClientTaxInfoDTO>();
    }
}
