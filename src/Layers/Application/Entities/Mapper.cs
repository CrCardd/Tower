using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class Mapper : IFile
{
    public Mapper(string featureNameEntity) : base($"{featureNameEntity.Split(';')[0]}{featureNameEntity.Split(';')[1]}Mapper")
    {
        string featureName = featureNameEntity.Split(';')[0];
        string entity = featureNameEntity.Split(';')[1];
        this.Content =
@$"
using AutoMapper;
using {Config.ProjectName}.Domain.Models;

namespace {Config.ProjectName}.Application.Features.{entity}.{featureName};

public class {featureName}{entity}Mapper : Profile
{{
    public Create{entity}apper()
    {{
        CreateMap<{featureName}{entity}Request, {entity}>();
        CreateMap<{entity}, {featureName}{entity}Response>();
    }}
}}
";
    }
}