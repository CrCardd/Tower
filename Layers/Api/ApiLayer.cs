using Tower.Layers.Archives;
using Tower.Configuration;
using Tower.Layers.Api.DefaultFiles;
using Tower.Layers.Api.Entities;

namespace Tower.Layers.Api;

public class ApiLayer : Layer
{
    public ApiLayer(string projectName) : base(projectName, LayersName.Api, "webapi")
    {
        this.RootFolder =
        new IFolder($"{this.ProjectName}.{LayersName.Api}",
        [
                new IFolder("Controllers"),
                new IFolder("Enums",
                [
                    new ApiRoutes(this.ProjectName)
                ]),
                new IFolder("Extensions",
                [
                    new CorsPolicyExtension(this.ProjectName)
                ]),
                new IFolder("Middlewares",
                [
                    new IFolder("ExceptionHandlers",
                    [
                        new ExceptionHandlerConfig(this.ProjectName)
                    ])
                ]),
        ]);
    }
    public override void CreateEntity(string name)
    {
        IArchive newEntity =
        new IFolder($"{this.ProjectName}.{LayersName.Api}",
        [
                new IFolder("Controllers", [
                    new Controller(name)
                ]),
        ]);
        newEntity.Create(Config.RootPath);
    }

    public override void CreateReferences()
    {
        ReferenceTo(LayersName.Application);
        ReferenceTo(LayersName.Persistence);
    }

    public override void InstallPackages()
    {
        Install("Microsoft.AspNetCore.OpenApi");
        Install("Microsoft.EntityFrameworkCore");
        Install("Microsoft.EntityFrameworkCore.Design");
        Install("Microsoft.EntityFrameworkCore.Tools");
    }
}