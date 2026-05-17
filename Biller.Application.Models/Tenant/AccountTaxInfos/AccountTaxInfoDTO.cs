using Biller.Application.Models.Tenant.TaxRegimes;
using Biller.Domain.Enums.Tenant;

namespace Biller.Application.Models.Tenant.AccountTaxInfos;

public class AccountTaxInfoDTO
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }
    public TaxInfoType Type { get; set; }
    public int? ClientId { get; set; }

    public TaxRegimeDTO TaxRegime { get; set; }
}
