namespace Tower.LayersArchives;

public class IFolder(string name, IArchive[]? archives = null) : IArchive(name)
{
    public readonly IArchive[]? Childrens  = archives;
    public readonly string name = name;
    // public IFolder(string name, IArchive[]? archives = null)
    // {
    //     this.Name = name;
    //     Console.WriteLine(this.Name);
    //     if (archives is not null)
    //         foreach (IArchive archive in archives)
    //         {
    //             archive.Parent = this;
    //             this.Children = archive;
    //             archive.Init();
    //         }

    //     if (this.Children is null)
    //         this.Init();
    // }

    public override void Create(string path)
    {

        Directory.CreateDirectory($"{path}/{this.Name}");
        // this.Parent?.Init();
        if(Childrens is not null)
            foreach (IArchive children in Childrens)
                children.Create($"{path}/{this.Name}");
            
    }
}