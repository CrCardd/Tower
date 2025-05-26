namespace Tower.Layers.Archives;

public class IFolder(string name, IArchive[]? archives = null, IFile? entity = null) : IArchive(name)
{
    public readonly IArchive[]? Childrens = archives;
    public readonly IFile? Entity = entity;
    public readonly string name = name;
    public override void Create(string path)
    {
        Directory.CreateDirectory($"{path}/{this.Name}");
        if (Childrens is not null)
            foreach (IArchive children in this.Childrens)
                children.Create($"{path}/{this.Name}");
    }
}