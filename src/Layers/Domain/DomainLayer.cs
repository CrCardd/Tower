using Tower.Configuration;
using Tower.Layers.Archives;
using Tower.Layers.Domain.DefaultFiles;
using Tower.Layers.Domain.Entities;

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
            new IFolder("Models",
            [
                new BaseModel(this.ProjectName)
            ])
        ]);
    }
    public override void CreateEntity(string name)
    {
        IArchive newEntity =
        new IFolder($"{this.ProjectName}.{LayersName.Domain}",
        [
                new IFolder("Models", [
                    new Model(name)
                ]),
        ]);
        newEntity.Create(Config.RootPath);
    }

    protected override void References(){}
    protected override void Packages(){}
    public override void CreateFeature(string name, string featureEntity, string? featureFolderName){}
}