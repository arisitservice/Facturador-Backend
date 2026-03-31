using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.UpdateClientCommand;

public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, ClientDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Receptores.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Client with Id {request.Id} was not found.");

        client.Name         = request.Name;
        client.TaxId        = request.TaxId;
        client.PostalCode   = request.PostalCode;
        client.TaxRegimeId  = request.TaxRegimeId;
        client.TaxAddress   = request.TaxAddress;
        client.BusinessName = request.BusinessName;

        await _unitOfWork.Receptores.UpdateAsync(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ClientDTO.FromEntity(client);
    }
}
