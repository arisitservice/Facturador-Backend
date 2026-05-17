using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Domain.Enums;
using FluentValidation;

namespace Biller.Application.UseCase.Tenant.Invoices.Commands.CreateIncomeInvoiceCommand;

public class CreateIncomeInvoiceCommandValidator : AbstractValidator<CreateIncomeInvoiceCommand>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public CreateIncomeInvoiceCommandValidator(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.IssuerTaxInfoId)
            .GreaterThan(0).WithMessage("El campo Emisor es obligatorio.")
            .MustAsync(async (id, cancellation) => await _unitOfWork.TaxInfos.ExistsAsync(id))
            .WithMessage("El Emisor seleccionado no existe.");

        RuleFor(x => x.ReceiverTaxInfoId)
            .GreaterThan(0).WithMessage("El campo Receptor es obligatorio.")
            .MustAsync(async (id, cancellation) => await _unitOfWork.TaxInfos.ExistsAsync(id))
            .WithMessage("El Receptor seleccionado no existe.");

        RuleFor(x => x.TaxInfo)
            .NotNull().WithMessage("El campo Información Fiscal es obligatorio.");

        When(x => x.TaxInfo != null, () =>
        {
            RuleFor(x => x.TaxInfo.InvoiceUsageId)
                .GreaterThan(0).WithMessage("El campo Uso de CFDI es obligatorio.");

            RuleFor(x => x.TaxInfo.PaymentCurrencyId)
                .GreaterThan(0).WithMessage("El campo Moneda es obligatorio.");

            RuleFor(x => x.TaxInfo.PaymentMethod)
                .NotEmpty().WithMessage("El campo Método de Pago es obligatorio.");

            RuleFor(x => x.TaxInfo.PaymentForm)
                .NotEmpty().WithMessage("El campo Forma de Pago es obligatorio.");

            // Validar que si la moneda no es MXN (id != 1), el tipo de cambio es obligatorio
            When(x => x.TaxInfo.PaymentCurrencyId != 1, () =>
            {
                RuleFor(x => x.TaxInfo.ExchangeRate)
                    .NotNull().WithMessage("El campo Tipo de Cambio es obligatorio cuando la moneda no es MXN.")
                    .GreaterThan(0).WithMessage("El Tipo de Cambio debe ser mayor a 0.");
            });
        });

    }
}
