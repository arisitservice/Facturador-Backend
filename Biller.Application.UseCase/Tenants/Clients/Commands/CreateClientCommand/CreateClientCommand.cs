using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.CreateClientCommand;

public sealed class CreateClientCommand : IRequest<ClientDTO>
{
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PostalCode { get; set; }
    public int TaxRegimeId { get; set; }
    public string TaxAddress { get; set; }
    public string BusinessName { get; set; }
}
