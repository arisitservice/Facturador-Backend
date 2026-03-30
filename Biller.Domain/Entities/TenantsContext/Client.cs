namespace Biller.Domain.Entities.TenantsContext;

public class Client
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool CanEmitBill { get; set; }


    //Foreign Keys
    public int TaxRegimeId { get; set; }


    //Relationships
    //public IList<Cfdi> Cfdis { get; set; }
    public TaxRegime TaxRegime { get; set; }
}
