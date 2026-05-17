using Biller.Domain.Entities.Common;
using Biller.Domain.Enums.Tenant;

namespace Biller.Domain.Entities.Tenant;

public class TaxInfo : BaseAuditableEntity
{
    public string      TaxAddress   { get; set; }
    public string      PostalCode   { get; set; }
    public string      BusinessName { get; set; }
    public string      TaxId        { get; set; }
    public bool        Default      { get; set; }
    public TaxInfoType Type         { get; set; }
    public int         TaxRegimeId  { get; set; }
    public int?        ClientId     { get; set; }

    public TaxRegime TaxRegime { get; set; }
    public Client    Client    { get; set; }
}
