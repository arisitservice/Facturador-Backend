
using FluentValidation.Results;

namespace Biller.Application.UseCase.Exceptions;

public class ValidationExceptionCustom: Exception
{
    public IEnumerable<ValidationFailure> Errors { get; set; }

    public ValidationExceptionCustom() : base("Uno o más fallos en la validación")
    {
        Errors = new List<ValidationFailure>();
    }

    public ValidationExceptionCustom(IEnumerable<ValidationFailure> errors) : this()
    {
        Errors = errors;
    }
}
