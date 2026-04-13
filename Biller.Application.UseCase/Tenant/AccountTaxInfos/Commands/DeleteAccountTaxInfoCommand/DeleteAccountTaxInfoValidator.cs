using FluentValidation;

namespace Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.DeleteAccountTaxInfoCommand;

public class DeleteAccountTaxInfoValidator : AbstractValidator<DeleteAccountTaxInfoCommand>
{
    public DeleteAccountTaxInfoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid AccountTaxInfo ID is required.");
    }
}
