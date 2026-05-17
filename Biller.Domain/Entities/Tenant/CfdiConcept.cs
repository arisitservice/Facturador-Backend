using Biller.Domain.Entities.Common;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class CfdiConcept:BaseAuditableEntity
{
    public int      CfdiId          { get; set; }
    public string   Description     { get; set; }
    public int      ProductId      { get; set; }
    public int      MeasurementUnitId  { get; set; }
    public decimal  Quantity        { get; set; }
    public decimal  UnitPrice   { get; set; }
    public decimal  Amount         { get; set; }
    public decimal  TaxTransfer     { get; set; }
    public Status  Status         { get; set; }

    public Cfdi Cfdi { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
    public Product Product { get; set; }

}
