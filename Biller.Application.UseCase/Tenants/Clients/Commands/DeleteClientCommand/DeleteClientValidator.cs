using FluentValidation;

namespace Biller.Application.UseCase.Tenants.Clients.Commands.DeleteClientCommand;

public class DeleteClientValidator : AbstractValidator<DeleteClientCommand>
{
    public DeleteClientValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid client ID is required.");
    }
}
