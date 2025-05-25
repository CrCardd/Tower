using System.Diagnostics;
using System.Runtime.InteropServices;
using Tower.Configuration;
using Tower.LayersArchives;
using Tower.LayersArchives.PersistenceLayer;

namespace Tower.Layers;

public class PersistenceLayer : Layer
{
    public PersistenceLayer(string ProjectName) : base(ProjectName, "Persistence")
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
        CreateLayer();
    }

}