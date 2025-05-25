using Tower.Configuration;

namespace Tower.Layers.Archives;

public class IFile(string name) : IArchive(name)
{
    protected string Content =  "";

    public override void Create(string path)
    {
        File.WriteAllText(
            $"{path}/{this.Name}{ConfigurationVariables.LanguageType}",
            this.Content
        );

    }
}