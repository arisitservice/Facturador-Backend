using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class MeasurementUnit
{
    public int Id { get; set; }
    public string SatCode { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}
