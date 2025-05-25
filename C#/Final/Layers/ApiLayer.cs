using System.Diagnostics;
using Tower.Configuration;
using Tower.LayersArchives;

namespace Tower.Layers;

public class ApiLayer : Layer
{
    public ApiLayer(string ProjectName) : base(ProjectName, "Api", "webapi")
    {
        this.RootFolder = new IFolder($"{ProjectName}.Api",
        [
                new IFolder("Controllers"),
                new IFolder("Enums",
                [

                ]),
                new IFolder("Extensions"),
                new IFolder("Middlewares"),
        ]);

        CreateLayer();
    }
}