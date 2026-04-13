using FluentValidation;

namespace Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.DeleteClientTaxInfoCommand;

public class DeleteClientTaxInfoValidator : AbstractValidator<DeleteClientTaxInfoCommand>
{
    public DeleteClientTaxInfoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid ClientTaxInfo ID is required.");
    }
}
