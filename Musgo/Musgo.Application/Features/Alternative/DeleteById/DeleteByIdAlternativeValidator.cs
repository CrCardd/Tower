
using FluentValidation;

namespace Musgo.Application.Features.Alternative.DeleteById;

public class DeleteByIdAlternativeValidator : AbstractValidator<DeleteByIdAlternativeRequest>
{
    public DeleteByIdAlternativeValidator()
    {
        //RuleFor(m => m.[propertie])
        //    .NotEmpty()
        //    .MaximumLength(64)
        //    .MinimumLength(8);
    }
}
