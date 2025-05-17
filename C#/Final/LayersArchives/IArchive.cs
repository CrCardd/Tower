using Tower.Configuration;

namespace Tower.LayersArchives;

public abstract class IArchive(string name)
{
    public string Name { get; set; } = name;
    public abstract void Create(string path);
    // public void Init()
    // {
    //     IArchive crr = this;
    //     while (crr.Parent != null)
    //     {
    //         crr = crr.Parent;
    //         this.Path = $"{this.Path}/{crr.Name}";
    //     }
        
    //     Console.WriteLine(crr.Path);
    //     if (!Directory.Exists($".{this.Path}"))
    //         Directory.CreateDirectory($".{this.Path}");

    //     this.Create();
    // }
}