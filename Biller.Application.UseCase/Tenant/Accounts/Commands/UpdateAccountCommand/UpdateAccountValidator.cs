using FluentValidation;

namespace Biller.Application.UseCase.Tenant.Accounts.Commands.UpdateAccountCommand;

public class UpdateAccountValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountValidator()
    {
        RuleFor(x => x.TenantName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("TenantName must be at least 3 characters.");

        RuleFor(x => x.Company)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Company must be at least 3 characters.");

        When(x => x.Image is not null, () =>
        {
            RuleFor(x => x.Image.Length)
                .GreaterThan(0).WithMessage("Image file cannot be empty.");

            RuleFor(x => x.Image.ContentType)
                .Must(ct => ct is "image/jpeg" or "image/png" or "image/webp")
                .WithMessage("Image must be a valid image file (jpeg, png, webp).");
        });
    }
}
