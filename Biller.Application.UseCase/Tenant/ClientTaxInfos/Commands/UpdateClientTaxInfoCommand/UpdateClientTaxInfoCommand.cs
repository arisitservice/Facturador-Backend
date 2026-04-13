using Biller.Application.Models.Tenant.Clients;
using MediatR;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.UpdateClientTaxInfoCommand;

public sealed class UpdateClientTaxInfoCommand : IRequest<ClientTaxInfoDTO>
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }
    public int TaxRegimeId { get; set; }
}
