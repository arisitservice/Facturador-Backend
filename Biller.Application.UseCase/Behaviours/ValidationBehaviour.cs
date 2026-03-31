

using Biller.Application.UseCase.Exceptions;
using FluentValidation;
using MediatR;

namespace Biller.Application.UseCase.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any()) 
        {
            var context = new ValidationContext<TRequest>(request);
            var validations = validators.Select(v => v.ValidateAsync(context, cancellationToken));
            var validationResults = await Task.WhenAll(validations);

            var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();

            if (failures.Any())
            {
                throw new ValidationExceptionCustom(failures);
            }
        }

        return await next();
    }
}
