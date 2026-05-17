using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Cfdis;
using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;
using Biller.Shared.ExtensionMethods;
using MediatR;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Biller.Application.UseCase.Tenant.Invoices.Commands.CreateIncomeInvoiceCommand;

public class CreateIncomeInvoiceHandler : IRequestHandler<CreateIncomeInvoiceCommand, CfdiDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public CreateIncomeInvoiceHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CfdiDTO> Handle(CreateIncomeInvoiceCommand request, CancellationToken cancellationToken)
    {

        // Validar que el emisor exista

        var issuer = await _unitOfWork.TaxInfos.ExistsAsync(request.IssuerTaxInfoId);

        if (!issuer)
        {
            throw new Exception("El emisor no existe.");
        }

        // Validar que el receptor exista

        var receiver = await _unitOfWork.TaxInfos.ExistsAsync(request.ReceiverTaxInfoId);

        if (!receiver) 
        {
            throw new Exception("El receptor no existe.");
        }

        decimal exchangeRate = request.TaxInfo.PaymentCurrencyId != 1 
            ? Math.Round(request.TaxInfo.ExchangeRate ?? 1, 4) 
            : 1;

        int paymentMethodId = request.TaxInfo.PaymentMethod == PaymentMethod.PPD ? 99 
            : request.TaxInfo.PaymentForm;


        ApplyTaxes applyTaxes = request.TaxInfo.PaymentCurrencyId == 1 && request.TaxCharged
            ? ApplyTaxes.Yes 
            : ApplyTaxes.No;

        // Crear el CFDI
        var cfdi = new Cfdi
        {
            ReceiptType = ReceiptType.Income,
            IssuerId = request.IssuerTaxInfoId,
            ReceiverId = request.ReceiverTaxInfoId,
            CfdiUseId = request.TaxInfo.InvoiceUsageId,
            CurrencyId = request.TaxInfo.PaymentCurrencyId,
            ExchangeRate = exchangeRate,
            PaymentForm = paymentMethodId,
            PaymentMethod = request.TaxInfo.PaymentMethod,
            ApplyTaxes = applyTaxes,
            Status = Status.Active,
            StampingStatus = StampingStatus.Pending,
            PaymentStatus = PaymentStatus.Pending,
            Created = DateTime.UtcNow
        };

        if(request.ProductServices is not null)
            cfdi.CfdiConcepts = request.ProductServices.Select(productService =>
            {
                decimal totalAmount = productService.Quantity * productService.UnitPrice;
                return new CfdiConcept
                {
                    Description = productService.DetailedDescription,
                    ProductId = productService.ProductServiceId,
                    MeasurementUnitId = productService.MeasureUnitId,
                    Quantity = productService.Quantity,
                    UnitPrice = productService.UnitPrice,
                    Amount = totalAmount,
                    TaxTransfer = request.TaxCharged ? (totalAmount * 0.16m) : 0,
                    Status = Status.Active
                };

            }).ToList();


        await _unitOfWork.Cfdis.AddAsync(cfdi);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return cfdi.CastTo<CfdiDTO>();
    }
}
