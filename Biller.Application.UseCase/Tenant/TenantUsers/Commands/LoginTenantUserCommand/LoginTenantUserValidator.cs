using FluentValidation;

namespace Biller.Application.UseCase.Tenant.TenantUsers.Commands.LoginTenantUserCommand;

public class LoginTenantUserValidator : AbstractValidator<LoginTenantUserCommand>
{
    public LoginTenantUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
