using Tower.LayersArchives;

namespace Tower.LayersArchives.PersistenceLayer;

public class IContext : IFile
{
    public IContext(string projectName) : base($"{projectName}Context")
    {
        this.Content =
        @"
namespace _.Persistence.Context;

public class Context 
{
    // :)    
}
        ";
    }
}
