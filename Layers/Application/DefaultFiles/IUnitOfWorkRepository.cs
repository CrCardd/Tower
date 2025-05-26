using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class IUnitOfWork : IFile
{
    public IUnitOfWork(string projectName) : base("IUnitOfWork")
    {
        this.Content =
@$"
namespace {projectName}.Application.Repository;

public interface IUnitOfWork
{{
    Task Save(CancellationToken cancellationToken);
}}
";
    }
}
