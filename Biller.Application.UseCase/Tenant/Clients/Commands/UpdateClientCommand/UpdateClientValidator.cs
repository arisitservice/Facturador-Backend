using FluentValidation;

namespace Biller.Application.UseCase.Tenant.Clients.Commands.UpdateClientCommand;

public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid client ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.");
    }
}
