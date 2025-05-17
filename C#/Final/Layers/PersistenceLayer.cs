using System.Runtime.InteropServices;
using Tower.Configuration;
using Tower.LayersArchives;
using Tower.LayersArchives.PersistenceLayer;

namespace Tower.Layers;

public class PersistenceLayer : Layer
{
    public PersistenceLayer(string ProjectName)
    {
        this.RootFolder =
            new IFolder($"{ProjectName}.Persistence",
                [
                    new IFolder("Context",
                        [
                            new IContext(ProjectName)
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

        this.RootFolder?.Create(ConfigurationVariables.RootPath);
    }

}