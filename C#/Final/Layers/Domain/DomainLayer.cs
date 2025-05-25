using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Domain.Files;

namespace Tower.Layers.Domain;

public class DomainLayer : Layer
{
    public DomainLayer(string ProjectName) : base(ProjectName, LayersName.Domain)
    {
        this.RootFolder =
        new IFolder($"{ProjectName}.{LayersName.Domain}",
        [
            new IFolder("Common",
            [
                new IFolder("Enums",
                [
                    new StatusCode(this.ProjectName)
                ]),
                new IFolder("Messages",
                [
                    new ExceptionMessages(this.ProjectName)
                ])
            ]),
            new IFolder("Models")
        ]);
        CreateLayer();
    }

    public override void CreateReferences(){}
    public override void InstallPackages(){}
}