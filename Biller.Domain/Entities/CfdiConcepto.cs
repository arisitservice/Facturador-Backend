using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class CfdiConcepto
{
    public int      Id  { get; private set; }
    public int      IdCfdi          { get; private set; }
    public string   Descripcion     { get; private set; }
    public int      IdServicio      { get; private set; }
    public int      IdUnidadMedida  { get; private set; }
    public decimal  Cantidad        { get; private set; }
    public decimal  ValorUnitario   { get; private set; }
    public decimal  Importe         { get; private set; }
    public decimal  TrasladoIva     { get; private set; }
    public Estatus  Estatus         { get; private set; }
    public int      CreatedBy       { get; private set; }
    public DateTime CreatedAt       { get; private set; }

    public Cfdi Cfdi { get; set; }

}
