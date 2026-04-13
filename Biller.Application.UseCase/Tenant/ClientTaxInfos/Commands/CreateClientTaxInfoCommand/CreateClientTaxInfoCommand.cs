using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.CreateClientTaxInfoCommand;

public sealed class CreateClientTaxInfoCommand : IRequest<ClientTaxInfoDTO>
{
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }
    public int ClientId { get; set; }
    public int TaxRegimeId { get; set; }
}
