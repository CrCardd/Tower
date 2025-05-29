
using FluentValidation;

namespace Musgo.Application.Features.Alternative.Create;

public class CreateAlternativeValidator : AbstractValidator<CreateAlternativeRequest>
{
    public CreateAlternativeValidator()
    {
        //RuleFor(m => m.[propertie])
        //    .NotEmpty()
        //    .MaximumLength(64)
        //    .MinimumLength(8);
    }
}
