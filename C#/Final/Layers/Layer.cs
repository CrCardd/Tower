using System.Diagnostics;
using Tower.Configuration;

namespace Tower.Layers.Archives;

public abstract class Layer(string ProjectName, string layerName, string Type = "classlib")
{
    protected string ProjectName = ProjectName;
    protected string LayerName = layerName;
    protected IArchive? RootFolder { get; set; }
    protected void CreateLayer()
    {
        this.RootFolder?.Create(ConfigurationVariables.RootPath);
        Process p = new Process();
        // p.StartInfo.RedirectStandardOutput = true;

        p.StartInfo.FileName = "dotnet";

        p.StartInfo.Arguments = $"new {Type} -o {ConfigurationVariables.RootPath}/{ProjectName}.{this.LayerName}";
        p.Start();
        p.WaitForExit();

        p.StartInfo.Arguments = $"new gitignore -o {ConfigurationVariables.RootPath}/{ProjectName}.{this.LayerName}";
        p.Start();
        p.WaitForExit();
    }

    public abstract void CreateReferences();
    protected void ReferenceTo(string referenceLayer)
    {
        Process process = new Process();
        // process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {ConfigurationVariables.RootPath}/{this.ProjectName}.{this.LayerName} reference {ConfigurationVariables.RootPath}/{this.ProjectName}.{referenceLayer}/{this.ProjectName}.{referenceLayer}.csproj";
        process.Start();
        process.WaitForExit();
    }

    public abstract void InstallPackages();
    protected void Install(string package)
    {
        Process process = new Process();
        // process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"add {ConfigurationVariables.RootPath}/{this.ProjectName}.{this.LayerName} package {package}";
        process.Start();
        process.WaitForExit();
    }
    

}