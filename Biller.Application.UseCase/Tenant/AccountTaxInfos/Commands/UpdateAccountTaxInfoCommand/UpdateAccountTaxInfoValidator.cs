using FluentValidation;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.UpdateAccountTaxInfoCommand;

public class UpdateAccountTaxInfoValidator : AbstractValidator<UpdateAccountTaxInfoCommand>
{
    public UpdateAccountTaxInfoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid AccountTaxInfo ID is required.");

        RuleFor(x => x.TaxId)
            .NotEmpty()
            .MinimumLength(10).WithMessage("Tax ID must be at least 10 characters.");

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Length(5).WithMessage("Postal code must be 5 characters.");

        RuleFor(x => x.TaxAddress)
            .NotEmpty().WithMessage("Tax address is required.");

        RuleFor(x => x.BusinessName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Business name must be at least 3 characters.");

        RuleFor(x => x.TaxRegimeId)
            .GreaterThan(0).WithMessage("A valid tax regime is required.");
    }
}
