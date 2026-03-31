using FluentValidation;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.UpdateClientCommand;

public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid client ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.");

        RuleFor(x => x.TaxId)
            .NotEmpty()
            .MinimumLength(10).WithMessage("Tax ID must be at least 10 characters.");

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Length(5).WithMessage("Postal code must be 5 characters.");

        RuleFor(x => x.TaxRegimeId)
            .GreaterThan(0).WithMessage("A valid tax regime is required.");

        RuleFor(x => x.TaxAddress)
            .NotEmpty().WithMessage("Tax address is required.");

        RuleFor(x => x.BusinessName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Business name must be at least 3 characters.");
    }
}
