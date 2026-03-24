using FluentValidation;

namespace Biller.Application.Models.Receptores;

public class ReceptorRequestValidator : AbstractValidator<ReceptorRequest>
{
    public ReceptorRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("name must be at least 3 characters");

        RuleFor(x => x.TaxId)
            .NotEmpty()
            .MinimumLength(10).WithMessage("tax ID must be at least 10 characters");

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MinimumLength(5).WithMessage("postal code must be at least 5 characters");

        RuleFor(x => x.TaxRegimeId)
            .NotEmpty()
            .WithMessage("tax regime must be at least 3 characters");

        RuleFor(x => x.BusinessName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("business name must be at least 3 characters");

        //RuleFor(x => x.AccessApp)
        //    .NotEmpty()
        //    .MinimumLength(3).WithMessage("access app must be at least 3 characters");
    }
}
