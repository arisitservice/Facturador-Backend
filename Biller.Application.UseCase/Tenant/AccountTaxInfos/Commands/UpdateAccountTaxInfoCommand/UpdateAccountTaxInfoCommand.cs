using Biller.Application.Models.Tenant.AccountTaxInfos;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.UpdateAccountTaxInfoCommand;

public sealed class UpdateAccountTaxInfoCommand : IRequest<AccountTaxInfoDTO>
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }
    public int TaxRegimeId { get; set; }
}
