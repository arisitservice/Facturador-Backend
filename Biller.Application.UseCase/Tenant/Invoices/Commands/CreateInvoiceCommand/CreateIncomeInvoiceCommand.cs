using Biller.Application.Models.Tenant.Cfdis;
using Biller.Domain.Enums;
using MediatR;


namespace Biller.Application.UseCase.Tenant.Invoices.Commands.CreateIncomeInvoiceCommand;

public sealed record CreateIncomeInvoiceCommand: IRequest<CfdiDTO>
{
    public int IssuerTaxInfoId { get; init; }
    public int ReceiverTaxInfoId { get; init; }
    public TaxInfoDto TaxInfo { get; init; }
    public List<ProductServiceDto>? ProductServices { get; init; }
    public bool TaxCharged { get; init; }
}

public sealed record TaxInfoDto
{
    public int InvoiceUsageId { get; init; }
    public int PaymentCurrencyId { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public int PaymentForm { get; init; }
    public decimal? ExchangeRate { get; init; }
}

public sealed record ProductServiceDto
{
    public string DetailedDescription { get; init; }
    public int ProductServiceId { get; init; }
    public int MeasureUnitId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}
