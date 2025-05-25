using System.Diagnostics;
using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Persistence.Files;

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

                    ]
                ),
                new IFolder("Tables",
                    [

                    ]
                ),
            ]
        );
        CreateLayer();
    }

    public override void CreateReferences()
    {
        ReferenceTo(LayersName.Application);
        ReferenceTo(LayersName.Domain);
    }

    public override void InstallPackages()
    {
        Install("Microsoft.EntityFrameworkCore");
        Install("Microsoft.EntityFrameworkCore.Design");
        Install("Microsoft.EntityFrameworkCore.Tools");
        Install("Microsoft.Extensions.Configuration.Abstractions");
        Install("Pomelo.EntityFrameworkCore.MySql");
    }
}