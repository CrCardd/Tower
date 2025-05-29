using System.Diagnostics;
using Tower.Configuration;

namespace Tower.Layers.Archives;

public abstract class Layer(string ProjectName, string layerName, string Type = "classlib")
{
    protected string ProjectName = ProjectName;
    protected string LayerName = layerName;
    protected IArchive? RootFolder { get; set; }



    public abstract void CreateEntity(string name);
    public abstract void CreateFeature(string name, string featureEntity);
    protected abstract void References();
    protected abstract void Packages();



    private void BuildLayer()
    {
        this.RootFolder?.Create(Config.RootPath);
        Process p = new Process();
        p.StartInfo.RedirectStandardOutput = true;

        p.StartInfo.FileName = "dotnet";

        p.StartInfo.Arguments = $"new {Type} -o {Config.RootPath}/{ProjectName}.{this.LayerName}";
        p.Start();
        p.WaitForExit();

        p.StartInfo.Arguments = $"new gitignore -o {Config.RootPath}/{ProjectName}.{this.LayerName}";
        p.Start();
        p.WaitForExit();
    }
    protected void ReferenceTo(string referenceLayer)
    {
        Process process = new Process();
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {Config.RootPath}/{this.ProjectName}.{this.LayerName} reference {Config.RootPath}/{this.ProjectName}.{referenceLayer}/{this.ProjectName}.{referenceLayer}.csproj";
        process.Start();
        process.WaitForExit();
    }
    protected void Install(string package)
    {
        Process process = new Process();
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {Config.RootPath}/{this.ProjectName}.{this.LayerName} package {package}";
        process.Start();
        process.WaitForExit();
    }
    


    public void CreateLayer()
    {
        int crrLine = Console.CursorTop;
        Console.WriteLine($"{ProjectName}.{LayerName} creating project...");
        BuildLayer();
        Console.SetCursorPosition(0, crrLine - 1);
        Console.WriteLine($"{ProjectName}.{LayerName} project created!              ");
    }
    public void CreateReferences()
    {
        int crrLine = Console.CursorTop;
        Console.WriteLine($"{ProjectName}.{LayerName} referencing projects...");
        References();
        Console.SetCursorPosition(0, crrLine - 1);
        Console.WriteLine($"{ProjectName}.{LayerName} projects referenced!              ");
    }
    public void InstallPackages()
    {
        int crrLine = Console.CursorTop;
        Console.WriteLine($"{ProjectName}.{LayerName} installing dependencies...");
        Packages();
        Console.SetCursorPosition(0, crrLine - 1);
        Console.WriteLine($"{ProjectName}.{LayerName} dependencies installed!              ");
    }

}