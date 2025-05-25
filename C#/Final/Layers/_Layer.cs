using System.Diagnostics;
using Tower.Configuration;
using Tower.LayersArchives;

namespace Tower.Layers;

public abstract class Layer(string ProjectName, string Layer, string Type = "classlib")
{
    protected IArchive? RootFolder { get; set; }
    protected void CreateLayer()
    {
        this.RootFolder?.Create(ConfigurationVariables.RootPath);
        Process p = new Process();
        p.StartInfo.RedirectStandardOutput = true;

        p.StartInfo.FileName = "dotnet";

        p.StartInfo.Arguments = $"new {Type} -o {ConfigurationVariables.RootPath}/{ProjectName}.{Layer}";
        p.Start();
        p.WaitForExit();

        p.StartInfo.Arguments = $"new gitignore -o {ConfigurationVariables.RootPath}/{ProjectName}.{Layer}";
        p.Start();
        p.WaitForExit();
    }
    
}