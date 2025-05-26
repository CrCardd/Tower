using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Persistence.DefaultFiles;

public class UnityOfWork : IFile
{
    public UnityOfWork(string projectName) : base("UnityOfWork")
    {
        this.Content =
@$"
using System.ComponentModel;
using {projectName}.Application.Repository;
using {projectName}.Persistence.Context;

namespace {projectName}.Persistence.Repositories;

public class UnitOfWork({projectName}Context ctx) : IUnitOfWork
{{
    private readonly {projectName}Context context = ctx;

    public Task Save(CancellationToken cancellationToken)
    {{
        return context.SaveChangesAsync(cancellationToken);
    }}
}}
";
    }
}
