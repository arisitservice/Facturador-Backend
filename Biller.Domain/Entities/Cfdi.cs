using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class Cfdi
{

    public int Id { get; set; }
    public string UUID { get; set; }
    public TipoComprobante TipoComprobante   { get; set; }
    public int?            IdFacturaRelacion  { get; set; }
    public int             IdReceptor         { get; set; }
    public int             IdEmisor         { get; set; }
    public int             IdUsoCfdi         { get; set; }
    public int             IdMoneda          { get; set; }
    public decimal         TipoCambio        { get; set; }
    public int             IdMedioPago       { get; set; }
    public MetodoPago      MetodoPago        { get; set; }
    public ObjetoImpuesto  ObjetoImpuesto    { get; set; }
    public Status         Estatus           { get; set; }
    public EstatusTimbrado EstatusTimbrado   { get; set; }
    public EstatusPago     EstatusPago       { get; set; }
    public string?         Notas             { get; set; }
    public int             CreatedBy         { get; set; }
    public DateTime        CreatedAt         { get; set; }

    public ICollection<CfdiConcepto> Conceptos { get; set; }
    public ICollection<CfdiComplementoPago> ComplementosPago { get; set; }

    public Client Receptor { get; set; }
    public Emisor Emisor { get; set; }

}
