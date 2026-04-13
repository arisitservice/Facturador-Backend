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

        client.Name = request.Name;

        await _unitOfWork.Clients.UpdateAsync(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return client.CastTo<ClientDTO>();
    }
}
