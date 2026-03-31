using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class TaxRegime
{
    public int Id { get; set; }
    public int SatCode { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }

    //Relationships
    public IList<Client> Clients { get; set; }
}
