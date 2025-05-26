using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Persistence.DefaultFiles;
using Tower.Layers.Persistence.Entities;

namespace Tower.Layers.Persistence;

public class PersistenceLayer : Layer
{
    public PersistenceLayer(string ProjectName) : base(ProjectName, LayersName.Persistence)
    {
        this.RootFolder =
        new IFolder($"{ProjectName}.{LayersName.Persistence}",
            [
                new IFolder("Context",
                    [
                        new Context(this.ProjectName),
                        new ContextFactory(this.ProjectName)
                    ]
                ),
                new IFolder("Repositories",
                [
                    new BaseRepository(this.ProjectName),
                    new UnityOfWork(this.ProjectName)
                ]),
                new IFolder("Tables"),
            ]
        );
    }
    public override void CreateEntity(string name)
    {
        IArchive newEntity =
        new IFolder($"{this.ProjectName}.{LayersName.Persistence}",
        [
                new IFolder("Tables", [
                    new Table(name)
                ]),
                new IFolder("Repositories",
                [
                    new IFolder($"{name}_",
                    [
                        new Repositories(name)
                    ])
                ])
        ]);
        newEntity.Create(Config.RootPath);
    }

    protected override void References()
    {
        ReferenceTo(LayersName.Application);
        ReferenceTo(LayersName.Domain);
    }

    protected override void Packages()
    {
        Install("Microsoft.EntityFrameworkCore");
        Install("Microsoft.EntityFrameworkCore.Design");
        Install("Microsoft.EntityFrameworkCore.Tools");
        Install("Microsoft.Extensions.Configuration.Abstractions");
        Install("Pomelo.EntityFrameworkCore.MySql");
    }
}