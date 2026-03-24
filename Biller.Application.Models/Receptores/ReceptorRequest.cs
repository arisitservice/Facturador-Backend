namespace Biller.Application.Models.Receptores;

public class ReceptorRequest
{
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PostalCode { get; set; }
    public int TaxRegimeId { get; set; }
    public int CfdiUseId { get; set; }
    public string TaxAddress { get; set; }
    public string BusinessName { get; set; }
}
