using Biller.Domain.Entities.Common;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities.Tenant;

public class CfdiPaymentComplement: BaseAuditableEntity
{
    public int CfdiId { get; set; }
    public int PaymentMethodId { get; set; }
    public int CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? OperationNumber { get; set; }
    public ApplyTaxes ApplyTaxes { get; set; }
    public string? Series { get; set; }
    public decimal Equivalence { get; set; }
    public int PartialityNumber { get; set; }
    public decimal PreviousBalanceAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal OutstandingPaidAmount { get; set; }
    public Status Status { get; set; }
   
    public Cfdi Cfdi { get; set; }
    public Currency Currency { get; set; }
}
