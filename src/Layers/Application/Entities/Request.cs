using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class Request : IFile
{
    public Request(string featureNameEntity) : base($"{featureNameEntity.Split(';')[0]}{featureNameEntity.Split(';')[1]}Request")
    {
        string featureName = featureNameEntity.Split(';')[0];
        string entity = featureNameEntity.Split(';')[1];
        this.Content =
@$"
using MediatR;

namespace {Config.ProjectName}.Application.Features.{entity}_.{featureName};

public sealed record {featureName}{entity}Request(

) : IRequest<{featureName}{entity}Response>;
";
    }
}