using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class Handler : IFile
{
    public Handler(string featureNameEntity) : base($"{featureNameEntity.Split(';')[0]}{featureNameEntity.Split(';')[1]}Handler")
    {
        string featureName = featureNameEntity.Split(';')[0];
        string entity = featureNameEntity.Split(';')[1];
        this.Content =
@$"
using AutoMapper;
using {Config.ProjectName}.Application.Repository;
using {Config.ProjectName}.Application.Repository.ModuleRepository;
using MediatR;

namespace {Config.ProjectName}.Application.Features.{entity}_.{featureName};

public class {featureName}{entity}(
    IUnitOfWork unitOfWork,
    I{entity}Repository {entity.ToLower()}Repository,
    IMapper mapper
) : IRequestHandler<{featureName}{entity}Request, {featureName}{entity}Response>
{{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly I{entity}Repository {entity.ToLower()}Repository = {entity.ToLower()}Repository;
    private readonly IMapper mapper = mapper;

    public async Task<{featureName}{entity}Response> Handle({featureName}{entity}Request request, CancellationToken cancellationToken)
    {{
        


        await unitOfWork.Save(cancellationToken);
        return mapper.Map<{featureName}{entity}Response>({entity.ToLower()});
    }}
}}
";
    }
}