using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.CreateClientCommand;

public sealed class CreateClientCommand : IRequest<ClientDTO>
{
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PostalCode { get; set; }
    public int TaxRegimeId { get; set; }
    public string TaxAddress { get; set; }
    public string BusinessName { get; set; }
}
