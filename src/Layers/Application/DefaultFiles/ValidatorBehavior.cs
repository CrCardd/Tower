using Tower.Layers.Archives;

namespace Tower.Layers.Application.DefaultFiles;

public class ValidationBehavior : IFile
{
    public ValidationBehavior(string projectName) : base("ValidatorBehavior")
    {
        this.Content =
@$"
using FluentValidation;
using MediatR;
using {projectName}.Application.Common.Exceptions;
using {projectName}.Domain.Common.Messages;

namespace {projectName}.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{{
    private readonly IEnumerable<IValidator<TRequest>> validators = validators;

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {{
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
            throw new BadRequestException(ExceptionMessage.BadRequest.Default, string.Join(""\n"", errors));

        return await next();
    }}
}}
";
    }
}
