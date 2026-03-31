using Biller.Application.Models.Tenants.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.UpdateClientCommand;

public sealed class UpdateClientCommand : IRequest<ClientDTO>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PostalCode { get; set; }
    public int TaxRegimeId { get; set; }
    public string TaxAddress { get; set; }
    public string BusinessName { get; set; }
}
