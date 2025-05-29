using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class Response : IFile
{
    public Response(string featureNameEntity) : base($"{featureNameEntity.Split(';')[0]}{featureNameEntity.Split(';')[1]}Response")
    {
        string featureName = featureNameEntity.Split(';')[0];
        string entity = featureNameEntity.Split(';')[1];
        this.Content =
@$"
namespace {Config.ProjectName}.Application.Features.{entity}.{featureName};

public sealed record {featureName}{entity}Response(

);
";
    }
}