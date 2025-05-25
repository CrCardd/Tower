using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Application.Files;

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
                new IFolder("Repository"),
                new ServiceExtension(this.ProjectName)
            ]);
        CreateLayer();
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