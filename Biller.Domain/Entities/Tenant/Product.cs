using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class Product
{
    public int Id { get; set; }
    public int SatCode { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}
