using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Models.Tenant.TaxRegimes;

public class TaxRegimeDTO
{
    public int Id { get; set; }
    public int SatCode { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    public static TaxRegimeDTO FromEntity(TaxRegime taxRegime) => new()
    {
        Id          = taxRegime.Id,
        SatCode     = taxRegime.SatCode,
        Description = taxRegime.Description,
        Status      = taxRegime.Status.ToString()
    };
}
