using System;
using FluentValidation;
using MediatR;

namespace HepsiBuradaApi.Application.Behaviour
{
    public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }


        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (failtures.Any())
                throw new ValidationException(failtures);

            return next();
        }
    }
}

