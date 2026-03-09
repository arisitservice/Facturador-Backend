using System.Xml.Serialization;

[XmlRoot("Comprobante", Namespace = "http://www.sat.gob.mx/cfd/4")]
public class Comprobante
{
    [XmlAttribute] public string Version { get; set; }
    [XmlAttribute] public string Serie { get; set; }
    [XmlAttribute] public string Folio { get; set; }
    [XmlAttribute] public string Fecha { get; set; }
    [XmlAttribute] public string Sello { get; set; }
    [XmlAttribute] public string NoCertificado { get; set; }
    [XmlAttribute] public string Certificado { get; set; }
    [XmlAttribute] public string FormaPago { get; set; }
    [XmlAttribute] public string MetodoPago { get; set; }
    [XmlAttribute] public string Moneda { get; set; }
    [XmlAttribute] public string Exportacion { get; set; }
    [XmlAttribute] public string TipoDeComprobante { get; set; }
    [XmlAttribute] public string LugarExpedicion { get; set; }
    [XmlAttribute] public string SubTotal { get; set; }
    [XmlAttribute] public string Total { get; set; }
    [XmlAttribute] public string TipoCambio { get; set; }
    [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string SchemaLocation { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public CfdiRelacionados CfdiRelacionados { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public Emisor Emisor { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public Receptor Receptor { get; set; }

    [XmlArray("Conceptos", Namespace = "http://www.sat.gob.mx/cfd/4")]
    [XmlArrayItem("Concepto", Namespace = "http://www.sat.gob.mx/cfd/4")]
    public List<Concepto> Conceptos { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public Impuestos Impuestos { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public Addenda Addenda { get; set; }
}

public class CfdiRelacionados
{
    [XmlAttribute] public string TipoRelacion { get; set; }

    [XmlElement("CfdiRelacionado", Namespace = "http://www.sat.gob.mx/cfd/4")]
    public List<CfdiRelacionado> CfdiRelacionado { get; set; }
}

public class CfdiRelacionado
{
    [XmlAttribute] public string UUID { get; set; }
}

public class Emisor
{
    [XmlAttribute] public string Rfc { get; set; }
    [XmlAttribute] public string Nombre { get; set; }
    [XmlAttribute] public string RegimenFiscal { get; set; }
}

public class Receptor
{
    [XmlAttribute] public string Rfc { get; set; }
    [XmlAttribute] public string Nombre { get; set; }
    [XmlAttribute] public string DomicilioFiscalReceptor { get; set; }
    [XmlAttribute] public string RegimenFiscalReceptor { get; set; }
    [XmlAttribute] public string UsoCFDI { get; set; }
}

public class Concepto
{
    [XmlAttribute] public string Cantidad { get; set; }
    [XmlAttribute] public string ClaveProdServ { get; set; }
    [XmlAttribute] public string ClaveUnidad { get; set; }
    [XmlAttribute] public string Descripcion { get; set; }
    [XmlAttribute] public string ValorUnitario { get; set; }
    [XmlAttribute] public string Importe { get; set; }
    [XmlAttribute] public string ObjetoImp { get; set; }
    [XmlAttribute] public string Unidad { get; set; }
    [XmlAttribute] public string NoIdentificacion { get; set; }

    [XmlElement(Namespace = "http://www.sat.gob.mx/cfd/4")]
    public Impuestos Impuestos { get; set; }
}

public class Impuestos
{
    [XmlAttribute] public string TotalImpuestosTrasladados { get; set; }

    [XmlArray("Traslados", Namespace = "http://www.sat.gob.mx/cfd/4")]
    [XmlArrayItem("Traslado", Namespace = "http://www.sat.gob.mx/cfd/4")]
    public List<Traslado> Traslados { get; set; }
}

public class Traslado
{
    [XmlAttribute] public string Base { get; set; }
    [XmlAttribute] public string Importe { get; set; }
    [XmlAttribute] public string Impuesto { get; set; }
    [XmlAttribute] public string TasaOCuota { get; set; }
    [XmlAttribute] public string TipoFactor { get; set; }
}

[XmlRoot("Addenda")]
public class Addenda
{
    [XmlElement("requestForPayment", Namespace = "https://mexico.e-factura.net/docs/MX")]
    public RequestForPayment RequestForPayment { get; set; }
}

public class RequestForPayment
{
    [XmlAttribute] public string DeliveryDate { get; set; }
    [XmlAttribute] public string contentVersion { get; set; }
    [XmlAttribute] public string documentStatus { get; set; }
    [XmlAttribute] public string documentStructureVersion { get; set; }
    [XmlAttribute] public string type { get; set; }
    [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string SchemaLocation { get; set; }

    [XmlElement("specialInstruction", Namespace = "https://mexico.e-factura.net/docs/MX")]
    public SpecialInstruction SpecialInstruction { get; set; }
}

public class SpecialInstruction
{
    [XmlAttribute] public string code { get; set; }

    [XmlElement("text", Namespace = "https://mexico.e-factura.net/docs/MX")]
    public string Text { get; set; }
}
