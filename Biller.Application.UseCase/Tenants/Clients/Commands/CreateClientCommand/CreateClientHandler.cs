using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.Clients;
using Biller.Domain.Entities.TenantsContext;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.CreateClientCommand;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateClientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Name         = request.Name,
            TaxId        = request.TaxId,
            PostalCode   = request.PostalCode,
            TaxRegimeId  = request.TaxRegimeId,
            TaxAddress   = request.TaxAddress,
            BusinessName = request.BusinessName
        };

        await _unitOfWork.Receptores.AddAsync(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ClientDTO.FromEntity(client);
    }
}
