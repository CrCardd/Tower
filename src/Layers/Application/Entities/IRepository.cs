using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class IRepository : IFile
{
    public IRepository(string name) : base($"I{name}Repository")
    {
        this.Content =
@$"
using {Config.ProjectName}.Domain.Models;

namespace {Config.ProjectName}.Application.Repository.{name}Repository;

public interface I{name}Repository : IBaseRepository<{name}> {{ }}
";
    }
}
