using Biller.Application.Models.Tenant.MeasurementUnits;
using Biller.Domain.Enums;

namespace Biller.Application.Models.Tenant.Cfdis;

public class CfdiConceptDTO
{
    public int Id { get; set; }
    public int CfdiId { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public int MeasurementUnitId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount { get; set; }
    public decimal TaxTransfer { get; set; }
    public Status Status { get; set; }

    public MeasurementUnitDTO MeasurementUnit { get; set; }
}
