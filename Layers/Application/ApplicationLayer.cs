using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Application.DefaultFiles;
using Tower.Layers.Application.Entities;

namespace Tower.Layers.Application;

public class ApplicationLayer : Layer
{
    public ApplicationLayer(string ProjectName) : base(ProjectName, LayersName.Application)
    {
        this.RootFolder =
            new IFolder($"{this.ProjectName}.{LayersName.Application}",
            [
                new IFolder("Common",
                [
                    new IFolder("Behaviors",
                    [
                        new ValidationBehavior(this.ProjectName)
                    ]),
                    new IFolder("Exceptions",
                    [
                        new AppException(this.ProjectName),
                        new BadRequestException(this.ProjectName),
                        new DuplicityException(this.ProjectName),
                        new NotFoundException(this.ProjectName)
                    ])
                ]),
                new IFolder("Config",
                [
                    new DotEnv(this.ProjectName)
                ]),
                new IFolder("Features"),
                new IFolder("Repository",
                [
                    new IBaseRepository(this.ProjectName),
                    new IUnitOfWork(this.ProjectName)
                ]),
                new ServiceExtension(this.ProjectName)
            ]);
    }
    public override void CreateEntity(string name)
    {
        IArchive newEntity =
        new IFolder($"{this.ProjectName}.{LayersName.Application}",
        [
                new IFolder("Repository", [
                    new IFolder($"{name}Repository",
                    [
                        new IRepository(name)
                    ])
                ]),
        ]);
        newEntity.Create(Config.RootPath);
    }

    public override void CreateReferences()
    {
        ReferenceTo(LayersName.Domain);
    }
    public override void InstallPackages()
    {
        Install("AutoMapper.Extensions.Microsoft.DependencyInjection");
        Install("FluentValidation.DependencyInjectionExtensions");
        Install("MediatR");
        Install("Microsoft.AspNetCore.Authentication");
        Install("Microsoft.Extensions.Identity.Core");
    }
}