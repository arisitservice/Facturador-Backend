
using Biller.Domain.Entities.Common;

namespace Biller.Domain.Entities.Tenant;

public class ClientTaxInfo: BaseAuditableEntity
{
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }


    //Foreign Keys
    public int ClientId { get; set; }
    public int TaxRegimeId { get; set; }


    //Relationships
    public Client Client { get; set; }
    public TaxRegime TaxRegime { get; set; }

}
