namespace Tower.LayersArchives;

public class IFolder(string name, IArchive[]? archives = null) : IArchive(name)
{
    public readonly IArchive[]? Childrens  = archives;
    public readonly string name = name;
    public override void Create(string path)
    {
        Directory.CreateDirectory($"{path}/{this.Name}");
        if(Childrens is not null)
            foreach (IArchive children in Childrens)
                children.Create($"{path}/{this.Name}");
            
    }
}