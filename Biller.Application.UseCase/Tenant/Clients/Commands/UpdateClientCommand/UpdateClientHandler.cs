using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Clients;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.UpdateClientCommand;

public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, ClientDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public UpdateClientHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Client with Id {request.Id} was not found.");

        client.Name         = request.Name;
        client.TaxId        = request.TaxId;
        client.PostalCode   = request.PostalCode;
        client.TaxRegimeId  = request.TaxRegimeId;
        client.TaxAddress   = request.TaxAddress;
        client.BusinessName = request.BusinessName;

        await _unitOfWork.Clients.UpdateAsync(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return client.CastTo<ClientDTO>();
    }
}
