namespace Biller.Application.Models.Receptores;

public class ReceptorResponse
{
    public int Id { get; set; }
    public string DomicilioFiscal { get; set; }
    public string CodigoPostal { get; set; }
    public string Nombre { get; set; }
    public string RazonSocial { get; set; }
    public string Rfc { get; set; }
    public int IdRegimenFiscal { get; set; }
    public int IdUsoCfdi { get; set; }
}
