

namespace Biller.Domain.Entities;

public class Emisor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string RegimenFiscal { get; set; }   
    public string Rfc { get; set; }

    public IList<Cfdi> Cfdis { get; set; }
}
