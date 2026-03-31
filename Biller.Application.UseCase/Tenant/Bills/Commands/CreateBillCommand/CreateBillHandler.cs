using MediatR;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Biller.Application.UseCase.Tenant.Bills.Commands.CreateBillCommand;

public class CreateBillHandler : IRequestHandler<CreateBillCommand,string>
{
    public async Task<string> Handle(CreateBillCommand request, CancellationToken cancellationToken)
    {
        var comprobante = new Comprobante
        {
            Version = "4.0",
            Serie = "A",
            Folio = "100",
            Fecha = "2025-06-01 12:00:00",
            Sello = "SelloDigitalDummy==",
            NoCertificado = "20001000000300022816",
            Certificado = "CertificadoBase64Dummy==",
            FormaPago = "01",
            MetodoPago = "PUE",
            Moneda = "MXN",
            Exportacion = "01",
            TipoDeComprobante = "I",
            LugarExpedicion = "06600",
            SubTotal = "1000.00",
            Total = "1160.00",
            SchemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd",
            Emisor = new Emisor
            {
                Rfc = "AAA010101AAA",
                Nombre = "EMPRESA DEMO SA DE CV",
                RegimenFiscal = "601"
            },
            Receptor = new global::Receptor
            {
                Rfc = "XAXX010101000",
                Nombre = "CLIENTE PUBLICO EN GENERAL",
                DomicilioFiscalReceptor = "06600",
                RegimenFiscalReceptor = "616",
                UsoCFDI = "G03"
            },
            Conceptos =
            [
                new Concepto
                {
                    ClaveProdServ = "81112100",
                    ClaveUnidad = "E48",
                    Cantidad = "1",
                    Descripcion = "Servicio de desarrollo de software",
                    ValorUnitario = "1000.00",
                    Importe = "1000.00",
                    ObjetoImp = "02",
                    Impuestos = new Impuestos
                    {
                        TotalImpuestosTrasladados = "160.00",
                        Traslados =
                        [
                            new Traslado
                            {
                                Base = "1000.00",
                                Impuesto = "002",
                                TipoFactor = "Tasa",
                                TasaOCuota = "0.160000",
                                Importe = "160.00"
                            }
                        ]
                    }
                }
            ],
            Impuestos = new Impuestos
            {
                TotalImpuestosTrasladados = "160.00",
                Traslados =
                [
                    new Traslado
                    {
                        Base = "1000.00",
                        Impuesto = "002",
                        TipoFactor = "Tasa",
                        TasaOCuota = "0.160000",
                        Importe = "160.00"
                    }
                ]
            },
            Addenda = new Addenda
            {
                RequestForPayment = new RequestForPayment
                {
                    DeliveryDate = "2025-06-01",
                    contentVersion = "1.0",
                    documentStatus = "ORIGINAL",
                    documentStructureVersion = "AMC8.1",
                    type = "380",
                    SchemaLocation = "https://mexico.e-factura.net/docs/MX https://mexico.e-factura.net/docs/MX/RequestForPayment.xsd",
                    SpecialInstruction = new SpecialInstruction
                    {
                        code = "ZZZ",
                        Text = "Instruccion especial de pago dummy"
                    }
                }
            }
        };

        var namespaces = new XmlSerializerNamespaces([
            new XmlQualifiedName("cfdi", "http://www.sat.gob.mx/cfd/4"),
            new XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XmlQualifiedName("add", "https://mexico.e-factura.net/docs/MX")
        ]);

        var serializer = new XmlSerializer(typeof(Comprobante));
        var settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };

        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(stream, settings);
        serializer.Serialize(writer, comprobante, namespaces);

        return Encoding.UTF8.GetString(stream.ToArray());
    }
}
