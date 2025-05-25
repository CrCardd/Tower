namespace Tower.Layers.Archives;

public abstract class IArchive(string name)
{
    public string Name { get; set; } = name;
    public abstract void Create(string path);
}