using System.Diagnostics;
using Tower.Configuration;

namespace Tower.Layers.Archives;

public abstract class Layer(string ProjectName, string layerName, string Type = "classlib")
{
    protected string ProjectName = ProjectName;
    protected string LayerName = layerName;
    protected IArchive? RootFolder { get; set; }
    public void CreateLayer()
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

        Console.WriteLine($"{ProjectName}.{LayerName} project created!");
    }
    public abstract void CreateEntity(string name);

    public void CreateReferences()
    {
        References();
        
        Console.WriteLine($"{ProjectName}.{LayerName} projects referenced!");
    }
    protected abstract void References();
    protected void ReferenceTo(string referenceLayer)
    {
        Process process = new Process();
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {Config.RootPath}/{this.ProjectName}.{this.LayerName} reference {Config.RootPath}/{this.ProjectName}.{referenceLayer}/{this.ProjectName}.{referenceLayer}.csproj";
        process.Start();
        process.WaitForExit();
    }

    public void InstallPackages()
    {
        Packages();
        
        Console.WriteLine($"{ProjectName}.{LayerName} dependencies installed!");
    }
    protected abstract void Packages();
    protected void Install(string package)
    {
        Process process = new Process();
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {Config.RootPath}/{this.ProjectName}.{this.LayerName} package {package}";
        process.Start();
        process.WaitForExit();
    }
    

}