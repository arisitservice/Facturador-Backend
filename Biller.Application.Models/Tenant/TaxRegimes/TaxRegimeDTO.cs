using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Models.Tenant.TaxRegimes;

public class TaxRegimeDTO
{
    public int Id { get; set; }
    public int SatCode { get; set; }
    public string Description { get; set; }
}
