using Biller.Application.Models.Tenant.CfdiUses;
using Biller.Application.Models.Tenant.Currencies;
using Biller.Domain.Enums;

namespace Biller.Application.Models.Tenant.Cfdis;

public class CfdiDTO
{
    public int Id { get; set; }
    public string UUID { get; set; }
    public ReceiptType ReceiptType { get; set; }
    public int ReceiverId { get; set; }
    public int IssuerId { get; set; }
    public int CfdiUseId { get; set; }
    public int CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; }
    public int PaymentForm { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ApplyTaxes ApplyTaxes { get; set; }
    public Status Status { get; set; }
    public StampingStatus StampingStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string? Notes { get; set; }
    public DateTime Created { get; set; }

    public TaxInfoDTO Receiver { get; set; }
    public TaxInfoDTO Issuer { get; set; }
    public CfdiUseDTO CfdiUse { get; set; }
    public CurrencyDTO Currency { get; set; }
    public List<CfdiConceptDTO> CfdiConcepts { get; set; }
}
