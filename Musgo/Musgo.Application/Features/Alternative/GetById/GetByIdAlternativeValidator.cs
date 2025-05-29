
using FluentValidation;

namespace Musgo.Application.Features.Alternative.GetById;

public class GetByIdAlternativeValidator : AbstractValidator<GetByIdAlternativeRequest>
{
    public GetByIdAlternativeValidator()
    {
        //RuleFor(m => m.[propertie])
        //    .NotEmpty()
        //    .MaximumLength(64)
        //    .MinimumLength(8);
    }
}
