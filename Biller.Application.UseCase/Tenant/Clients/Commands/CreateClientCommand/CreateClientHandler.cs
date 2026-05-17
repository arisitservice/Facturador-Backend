using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums.Tenant;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.CreateClientCommand;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public CreateClientHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Name = request.Name,
            TaxInfos = new List<TaxInfo>
            {
                new TaxInfo
                {
                    TaxId        = request.TaxId,
                    PostalCode   = request.PostalCode,
                    TaxRegimeId  = request.TaxRegimeId,
                    TaxAddress   = request.TaxAddress,
                    BusinessName = request.BusinessName,
                    Default      = true,
                    Type         = TaxInfoType.Client
                }
            }
        };

        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return client.CastTo<ClientDTO>();
    }
}
