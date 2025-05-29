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
using {Config.ProjectName}.Application.Common.Exceptions;
using {Config.ProjectName}.Application.Repository;
using {Config.ProjectName}.Application.Repository.ModuleRepository;
using {Config.ProjectName}.Domain.Common.Messages;
using {Config.ProjectName}.Domain.Models;
using MediatR;

namespace {Config.ProjectName}.Application.Features.{entity}.{featureName};

public class {featureName}{entity}(
    IUnitOfWork unitOfWork,
    I{entity}Repository {entity.ToLower()}Repository,
    IMapper mapper
) : IRequestHandler<Create{entity}Request, Create{entity}Response>
{{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly I{entity}Repository {entity.ToLower()}Repository = {entity.ToLower()}Repository;
    private readonly IMapper mapper = mapper;

    public async Task<Create{entity}Response> Handle(Create{entity}Request request, CancellationToken cancellationToken)
    {{
        


        await unitOfWork.Save(cancellationToken);
        return mapper.Map<Create{entity}Response>({entity.ToLower()});
    }}
}}
";
    }
}