using Biller.Domain.Entities.Common;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class Cfdi: BaseAuditableEntity  
{

    public int?             InvoiceRelatedId      { get; set; }
    public string?          UUID                { get; set; }
    public ReceiptType      ReceiptType         { get; set; }
    public int              ReceiverId          { get; set; }
    public int              IssuerId            { get; set; }
    public int              CfdiUseId           { get; set; }
    public int              CurrencyId          { get; set; }
    public decimal          ExchangeRate        { get; set; }
    public int              PaymentMethodId     { get; set; }
    public PaymentMethod    PaymentMethod       { get; set; }
    public ApplyTaxes       ApplyTaxes          { get; set; }
    public Status           Status              { get; set; }
    public StampingStatus   StampingStatus      { get; set; }
    public PaymentStatus    PaymentStatus       { get; set; }
    public string?          Notes               { get; set; }


    //public ICollection<CfdiConcepto> Conceptos { get; set; }
    //public ICollection<CfdiComplementoPago> ComplementosPago { get; set; }


    public TaxInfo  Receiver { get; set; }
    public TaxInfo  Issuer   { get; set; }
    public CfdiUse  CfdiUse   { get; set; }
    public Currency  Currency   { get; set; }

    public IList<CfdiConcept> CfdiConcepts {  get; set; }
    public IList<CfdiPaymentComplement> CfdiPaymentComplements { get; set; }
}
