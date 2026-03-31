using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Queries.GetClientByIdQuery;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDTO?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientDTO?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Receptores.GetByIdAsync(request.Id);
        return client is null ? null : ClientDTO.FromEntity(client);
    }
}
