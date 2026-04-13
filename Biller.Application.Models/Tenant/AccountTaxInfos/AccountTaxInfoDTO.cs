using Biller.Application.Models.Tenant.TaxRegimes;

namespace Biller.Application.Models.Tenant.AccountTaxInfos;

public class AccountTaxInfoDTO
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }

    public TaxRegimeDTO TaxRegime { get; set; }
}
