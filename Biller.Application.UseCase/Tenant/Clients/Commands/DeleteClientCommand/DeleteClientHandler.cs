using Biller.Application.Infrastructure.Interface.Persistence;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.DeleteClientCommand;

public class DeleteClientHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public DeleteClientHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Receptores.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Client with Id {request.Id} was not found.");

        await _unitOfWork.Receptores.DeleteAsync(client.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
