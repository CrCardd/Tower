using Tower.Configuration;

namespace Tower.LayersArchives;

public class IFile(string name) : IArchive(name)
{
    public string Content = "";
    public override void Create(string path)
    => File.WriteAllText(
            $"{path}/{this.Name}{ConfigurationVariables.LanguageType}",
            this.Content
        );
}