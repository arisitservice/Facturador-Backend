using System;
using System.Collections.Generic;
using System.Text;

namespace Biller.Domain.Entities;

public class Receptor
{
    public int Id { get; set; }
    public string DomicilioFiscal { get; set; }
    public string Nombre { get; set; }
    public string RegimenFiscal { get; set; }
    public string Rfc { get; set; }
    public string UsoCFDI { get; set; }


    public IList<Cfdi> Cfdis { get; set; }
}
