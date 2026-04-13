using Biller.Application.Infrastructure.Interface.Persistence;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.DeleteClientTaxInfoCommand;

public class DeleteClientTaxInfoHandler : IRequestHandler<DeleteClientTaxInfoCommand>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public DeleteClientTaxInfoHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteClientTaxInfoCommand request, CancellationToken cancellationToken)
    {
        var clientTaxInfo = await _unitOfWork.ClientTaxInfos.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"ClientTaxInfo with Id {request.Id} was not found.");

        await _unitOfWork.ClientTaxInfos.DeleteAsync(clientTaxInfo.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
