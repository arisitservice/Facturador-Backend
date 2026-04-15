namespace Biller.Domain.Entities.Tenant;

public class ClientTaxInfo : TaxInfoBase
{
    public int    ClientId { get; set; }
    public Client Client   { get; set; }
}
