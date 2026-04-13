using Biller.Application.Models.Tenant.AccountTaxInfos;
using MediatR;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.CreateAccountTaxInfoCommand;

public sealed class CreateAccountTaxInfoCommand : IRequest<AccountTaxInfoDTO>
{
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }
    public int TaxRegimeId { get; set; }
}
