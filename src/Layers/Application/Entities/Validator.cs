using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class Validator : IFile
{
    public Validator(string featureNameEntity) : base($"{featureNameEntity.Split(';')[0]}{featureNameEntity.Split(';')[1]}Validator")
    {
        string featureName = featureNameEntity.Split(';')[0];
        string entity = featureNameEntity.Split(';')[1];
        string? folderName = featureNameEntity.Split(';').LastOrDefault();
        this.Content =
@$"
using FluentValidation;

namespace {Config.ProjectName}.Application.Features.{(entity == folderName ? $"{folderName}_" : folderName)}.{featureName};

public class {featureName}{entity}Validator : AbstractValidator<{featureName}{entity}Request>
{{
    public {featureName}{entity}Validator()
    {{
        //RuleFor(m => m.[propertie])
        //    .NotEmpty()
        //    .MaximumLength(64)
        //    .MinimumLength(8);
    }}
}}
";
    }
}