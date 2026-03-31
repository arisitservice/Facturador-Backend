using FluentValidation;

namespace Biller.Application.UseCase.Main.Tenant.Commands.CreateTenantCommand;

public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantValidator()
    {
        RuleFor(x => x.Tenant).NotNull().WithMessage("Tenant info is required");

        RuleFor(x => x.Tenant.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Tenant name must be at least 3 characters");

        RuleFor(x => x.Tenant.Company)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Company must be at least 3 characters");

        RuleFor(x => x.Owner).NotNull().WithMessage("Owner info is required");

        RuleFor(x => x.Owner.Username)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Username must be at least 3 characters");

        RuleFor(x => x.Owner.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Owner.Password)
            .NotEmpty()
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");
    }
}
